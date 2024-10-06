using ExtensionMethods;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Rewired.ComponentControls.Effects.RotateAroundAxis;

public class Flea : MonoBehaviour
{
    PlayerInput input;
    [HideInInspector]
    public Rigidbody2D rb;

    public float JumpHeight = 10f;
    public float MoveSpeed = 10f;
    public float AddedFastFallGravity = 5f;
    public float HorizontalDragCoefficient = 1f;
    public float SpinHitUpForce = 100f;
    public LayerMask GroundLayers;

    bool IsTouchingGround => Physics2D.Raycast(transform.position, Vector2.down, 0.65f, GroundLayers);
    [HideInInspector]
    public bool TouchingGround = false;

    public int FleaNumber = 0;

    public bool UseRecordedData = false;

    public List<FrameInput> inputs = new();

    public float SpinCircleRadius = 2f;

    public List<Color> fleaColors = new();

    public Color FleaColor => fleaColors[FleaNumber % fleaColors.Count];

    public SpriteRenderer HatSpriteRenderer;

    public GameObject Body;

    [HideInInspector]
    public int ComboCounter = 0;

    [HideInInspector]
    public UnityEvent Twirl = new();

    public ParticleSystem SpinParticles;
    public ParticleSystem DustJumpParticles;
    public class FrameInput
    {
        public float MoveInput = 0f;
        public bool JumpIsPressed = false;
        public bool JumpJustPressed = false;
        public bool JustJustReleased = false;
        public bool SpinIsPressed = false;
        public bool SpinJustPressed = false;
        public bool SpinJustReleased = false;
    }

    void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        HatSpriteRenderer.color = FleaColor;
        GetComponentInChildren<TrailRenderer>().startColor = FleaColor;
    }
    public List<FrameInput> RecordedInputs => FleaNumber < GameManager.RecordedInputs.Count ? GameManager.RecordedInputs[FleaNumber] : null;
    int FixedUpdateCounter = 0;
    public FrameInput currentFrameInput;
    private void FixedUpdate()
    {
        if (UseRecordedData)
        {
            if(FixedUpdateCounter < RecordedInputs.Count)
            {
                currentFrameInput = GameManager.RecordedInputs[FleaNumber][FixedUpdateCounter];
            }
            else
            {
                return;
            }
        }
        else
        {
            currentFrameInput = new FrameInput()
            {
                MoveInput = input.MoveInput,
                JumpIsPressed = input.JumpIsPressed,
                JumpJustPressed = input.JumpJustPressed,
                JustJustReleased = input.JustJustReleased,
                SpinIsPressed = input.SpinIsPressed,
                SpinJustPressed = input.SpinJustPressed,
                SpinJustReleased = input.SpinJustReleased,
            };
            inputs.Add(currentFrameInput);
        }

        var InAir = !TouchingGround;
        TouchingGround = IsTouchingGround;
        if(InAir && TouchingGround)
        {
            DustJumpParticles.Emit(10);
        }

        HandleInputs(currentFrameInput);

        AddHorizontalDrag();

        if(Mathf.Abs(rb.velocity.x) > 0.5f)
        {
            transform.localScale = new Vector3(rb.velocity.x < 0 ? -1 : 1, 1, 1);
        }

        FixedUpdateCounter++;
    }

    void HandleInputs(FrameInput frameInput)
    {
        Move(frameInput.MoveInput);
        if (frameInput.JumpJustPressed && TouchingGround)
        {
            Jump();
        }
        if (!frameInput.JumpIsPressed)
        {
            rb.AddForce(Vector2.down * AddedFastFallGravity);
        }
        if(frameInput.SpinJustPressed && !TouchingGround)
        {
            DoTwirl();
        }
    }

    float TimeOfLastTwirl = float.MinValue;
    float TimeBetweenTwirls = 0.5f;
    private void DoTwirl()
    {
        if (Time.time - TimeOfLastTwirl < TimeBetweenTwirls)
        {
            return;
        }
        TimeOfLastTwirl = Time.time;
        var hits = Physics2D.OverlapCircleAll(transform.position, SpinCircleRadius);
        bool HitFlea = false;
        foreach (var hit in hits)
        {
            var flea = hit.GetComponent<Flea>();
            if (flea != null && flea != this)
            {
                HitFlea = true;
                flea.GetBonked();
            }
        }
        ScoreManager.AddTrick(this, HitFlea ? ScoreManager.TrickType.SpinFlea : ScoreManager.TrickType.Spin);
        SpinParticles.Emit(20);
        Twirl.Invoke();
    }

    private void AddHorizontalDrag()
    {
        if (DragDisabled) return;
        var speed = Mathf.Abs(rb.velocity.x);
        // Calculate the drag force magnitude
        float dragForceMagnitude = 0.5f * HorizontalDragCoefficient * speed * speed;

        // Calculate the drag force direction (opposite to velocity)
        Vector2 dragForce = -dragForceMagnitude * rb.velocity.GetFlattened();

        // Apply the drag force to the Rigidbody
        rb.AddForce(dragForce, ForceMode2D.Force);
    }

    bool DragDisabled = false;
    public void TempDisableDrag(float time)
    {
        DragDisabled = true;
        LeanTween.value(gameObject, 0f, 1f, time).setOnComplete(() => DragDisabled = false);
    }

    public void GetBonked()
    {
        rb.velocity = new Vector3(rb.velocity.x, SpinHitUpForce);
        ScoreManager.AddTrick(this, ScoreManager.TrickType.GetSpunByFlea);
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, JumpHeight);
        DustJumpParticles.Emit(10);
        ScoreManager.AddTrick(this, ScoreManager.TrickType.Jump);
    }

    private void Move(float moveAmount)
    {
        rb.AddForce(Vector3.right * moveAmount * MoveSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, SpinCircleRadius);
    }
}
