using ExtensionMethods;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Rewired.ComponentControls.Effects.RotateAroundAxis;

public class Flea : MonoBehaviour
{
    PlayerInput input;
    Rigidbody2D rb;

    public float JumpHeight = 10f;
    public float MoveSpeed = 10f;
    public float AddedFastFallGravity = 5f;
    public float HorizontalDragCoefficient = 1f;
    public float SpinHitUpForce = 100f;
    public LayerMask GroundLayers;

    bool TouchingGround => Physics2D.Raycast(transform.position, Vector2.down, 1.1f, GroundLayers);

    public int FleaNumber = 0;

    public bool UseRecordedData = false;

    public List<FrameInput> inputs = new();

    public float SpinCircleRadius = 2f;

    public List<Color> fleaColors = new();

    public GameObject Body;

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
        var sr = Body.GetComponentInChildren<SpriteRenderer>();
        sr.color = fleaColors[FleaNumber % fleaColors.Count];
    }
    public List<FrameInput> RecordedInputs => FleaNumber < GameManager.RecordedInputs.Count ? GameManager.RecordedInputs[FleaNumber] : null;
    int FixedUpdateCounter = 0;
    private void FixedUpdate()
    {
        FrameInput frameInput;
        if (UseRecordedData)
        {
            if(FixedUpdateCounter < RecordedInputs.Count)
            {
                frameInput = GameManager.RecordedInputs[FleaNumber][FixedUpdateCounter];
            }
            else
            {
                return;
            }
        }
        else
        {
            frameInput = new FrameInput()
            {
                MoveInput = input.MoveInput,
                JumpIsPressed = input.JumpIsPressed,
                JumpJustPressed = input.JumpJustPressed,
                JustJustReleased = input.JustJustReleased,
                SpinIsPressed = input.SpinIsPressed,
                SpinJustPressed = input.SpinJustPressed,
                SpinJustReleased = input.SpinJustReleased,
            };
            inputs.Add(frameInput);
        }

        HandleInputs(frameInput);

        AddHorizontalDrag();

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
            Debug.Log("Spin!");
            LeanTween.cancel(Body);
            Body.transform.rotation = Quaternion.identity;
            LeanTween.rotateAroundLocal(Body, Vector3.forward, 360f, 0.2f).setEaseOutCubic();
            var hits = Physics2D.OverlapCircleAll(transform.position, SpinCircleRadius);
            foreach(var hit in hits)
            {
                var flea = hit.GetComponent<Flea>();
                if (flea != null && flea != this)
                {
                    flea.GetBonked();
                }
            }
        }
    }

    private void AddHorizontalDrag()
    {
        var speed = rb.velocity.x;
        // Calculate the drag force magnitude
        float dragForceMagnitude = 0.5f * HorizontalDragCoefficient * speed * speed;

        // Calculate the drag force direction (opposite to velocity)
        Vector2 dragForce = -dragForceMagnitude * rb.velocity.GetFlattened();

        // Apply the drag force to the Rigidbody
        rb.AddForce(dragForce, ForceMode2D.Force);
    }

    private void Update()
    {
        
    }

    public void GetBonked()
    {
        rb.velocity = new Vector3(rb.velocity.x, SpinHitUpForce);
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, JumpHeight);
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
