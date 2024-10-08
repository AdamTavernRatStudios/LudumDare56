using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogoStick : CircusItem
{
    public CollisionListener collisionListener;
    public Transform FleaPosition;
    public Rigidbody2D rb;
    public float BouncePower = 5f;
    public float MoveAmount = 1f;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        collisionListener.CollisionEnter2D.AddListener(HandleCollision);
        anim = GetComponent<Animator>();
    }

    private void HandleCollision(Collision2D collision)
    {
        var f = collision.gameObject.GetComponent<Flea>();
        if (TryAddPlayer(f))
        {
            DoInteractionOnDelay(7);
        }
        Bounce(collision.relativeVelocity.y);
    }

    void Bounce(float relativeVel)
    {
        if (relativeVel > 0)
        {
            var bp = BouncePower;
            if (flea?.currentFrameInput.JumpIsPressed ?? false)
            {
                bp *= 2f;
            }
            rb.velocity = new Vector2(rb.velocity.x, bp);
            anim.SetTrigger("Bounce");
        }
        if (Occupied)
        {
            ScoreManager.AddTrick(flea, ScoreManager.TrickType.PogoStickBounce);
            AudioManager.PlayClip(Audio.Clips.PogoBounce, AudioManager.GenericRandomizedData);

        }
    }
    void Update()
    {
        if (Occupied)
        {
            flea.transform.position = FleaPosition.position;
        }
    }

    private void FixedUpdate()
    {
        if (Occupied)
        {
            rb.AddForce(Vector2.right * flea.currentFrameInput.MoveInput * MoveAmount);
            if (flea.currentFrameInput.SpinJustPressed)
            {
                DoInteraction();
            }
        }
    }

    public override void DoInteraction()
    {
        RemovePlayer();
    }
}
