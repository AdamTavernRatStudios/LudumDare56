using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : CircusItem
{
    public CollisionListener collisionListener;
    public Animator anim;
    public Transform BlastPoint;
    public ParticleSystem PS;
    public float BlastPower = 100f;
    // Start is called before the first frame update
    void Start()
    {
        collisionListener.TriggerEnter2D.AddListener(HandleTriggerEnter);
    }

    bool BlastJustHappened = false;
    private void HandleTriggerEnter(Collider2D arg0)
    {
        if (Occupied || BlastJustHappened)
        {
            return;
        }
        var flea = arg0.GetComponent<Flea>();
        AddPlayer(flea);
        if (Occupied)
        {
            anim.SetTrigger("Aim");
        }
        StartCoroutine(DoInteractionRoutine(5));
    }

    public override void DoInteraction()
    {
        anim.SetTrigger("Blast");
        BlastJustHappened = true;
        PS.Emit(20);
        var f = RemovePlayer();
        f.transform.position = BlastPoint.transform.position;
        f.rb.velocity = (BlastPoint.transform.up * BlastPower);
        f.TempDisableDrag(0.5f);
        ScoreManager.AddTrick(f, ScoreManager.TrickType.CannonBlast);
        StopAllCoroutines();
    }

    public void ResetBlast()
    {
        BlastJustHappened = false;
    }
}
