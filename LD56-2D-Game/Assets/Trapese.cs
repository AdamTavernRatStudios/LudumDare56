using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapese : CircusItem
{
    public CollisionListener handle;
    public float LeapBoost = 5f;
    // Start is called before the first frame update
    void Start()
    {
        handle.TriggerEnter2D.AddListener(HandleTriggerEnter);
    }

    private void HandleTriggerEnter(Collider2D other)
    {
        if (TryAddPlayer(other.GetComponent<Flea>()))
        {
            ScoreManager.AddTrick(flea, ScoreManager.TrickType.GrabTrapese);
            DoInteractionOnDelay(10f);
        }
    }

    Vector3 LastTwoPositionsDiff = Vector3.zero;
    Vector3 LastPos = Vector3.zero;
    void FixedUpdate()
    {
        if (Occupied)
        {
            flea.transform.position = handle.transform.position;
            if (flea.currentFrameInput.JumpJustPressed)
            {
                DoInteraction();
            }
        }
        LastTwoPositionsDiff = (handle.transform.position - LastPos).normalized;
        LastPos = handle.transform.position;
    }

    public override void DoInteraction()
    {
        var f = RemovePlayer();
        f.rb.velocity = LastTwoPositionsDiff * LeapBoost + Vector3.up * 5;
        ScoreManager.AddTrick(f, ScoreManager.TrickType.ExitTrapese);
    }
}
