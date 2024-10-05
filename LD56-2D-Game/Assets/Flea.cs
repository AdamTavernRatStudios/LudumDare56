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


    bool JumpIsPressed = false;
    float MoveInput = 0f;
    public float AddedFastFallGravity = 5f;
    public float HorizontalDragCoefficient = 1f;
    public LayerMask GroundLayers;

    bool TouchingGround => Physics2D.Raycast(transform.position, Vector2.down, 1.1f, GroundLayers);

    public int FleaNumber = 0;

    public bool UseRecordedData = false;

    public List<FrameInput> inputs = new();

    public List<Color> fleaColors = new();

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
        GetComponentInChildren<SpriteRenderer>().color = fleaColors[FleaNumber % fleaColors.Count];
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

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, JumpHeight);
    }

    private void Move(float moveAmount)
    {
        rb.AddForce(Vector3.right * moveAmount * MoveSpeed);
    }
}
