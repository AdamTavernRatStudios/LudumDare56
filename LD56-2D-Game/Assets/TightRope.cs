using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TightRope : CircusItem
{
    public CollisionListener collisionListener;
    Collider2D coll;
    Animator anim;
    public LineRenderer lineRenderer;
    public GameObject LeftPole;
    public GameObject RightPole;
    public float DistanceWalkedPerTrick = 3f;
    // Start is called before the first frame update
    void Start()
    {
        collisionListener.CollisionEnter2D.AddListener(HandleCollision);
        collisionListener.CollisionExit2D.AddListener(HandleCollisionExit);
        coll = collisionListener.GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    private void HandleCollisionExit(Collision2D arg0)
    {
        if (!Occupied)
        {
            return;
        }
        if(flea == arg0.gameObject.GetComponent<Flea>())
        {
            flea.transform.parent = null;
            DoInteraction();
        }
    }

    private void HandleCollision(Collision2D other)
    {
        if(other.gameObject.GetComponent<Flea>() != null && Occupied)
        {
            RemovePlayer();
        }
        if (TryAddPlayer(other.gameObject.GetComponent<Flea>()))
        {
            ScoreManager.AddTrick(flea, ScoreManager.TrickType.EnterTightRope);
            DoInteractionOnDelay(10f);
            AudioManager.PlayClip(Audio.Clips.TrapezeSound);
            flea.transform.parent = collisionListener.transform;
            anim.SetTrigger("Active");
            PrevPos = flea.transform.position;
            DistanceTraveled = 0f;
        }
    }

    public override void DoInteraction()
    {
        ScoreManager.AddTrick(flea, ScoreManager.TrickType.ExitTightRope);
        RemovePlayer();
        StartCoroutine(ResetCollider());
        anim.SetTrigger("Idle");
        AudioManager.PlayClip(Audio.Clips.TrapezeSound);

    }

    IEnumerator ResetCollider()
    {
        coll.enabled = false;
        yield return new WaitForSeconds(0.5f);
        coll.enabled = true;
    }

    float DistanceTraveled = 0f;
    Vector3 PrevPos = Vector3.zero;
    private void FixedUpdate()
    {
        if (!Occupied)
        {
            lineRenderer.SetPositions(new Vector3[]
            {
                new Vector3(LeftPole.transform.position.x, lineRenderer.transform.position.y, 0),
                new Vector3((LeftPole.transform.position.x + RightPole.transform.position.x) / 2, lineRenderer.transform.position.y, 0),
                new Vector3(RightPole.transform.position.x, lineRenderer.transform.position.y, 0)
            });
        }
        else
        {
            lineRenderer.SetPositions(new Vector3[]
            {
                new Vector3(LeftPole.transform.position.x, lineRenderer.transform.position.y, 0),
                new Vector3(flea.transform.position.x, collisionListener.transform.position.y, 0),
                new Vector3(RightPole.transform.position.x, lineRenderer.transform.position.y, 0)
            });
            DistanceTraveled += Vector3.Distance(flea.transform.position, PrevPos);
            PrevPos = flea.transform.position;
            if(DistanceTraveled > DistanceWalkedPerTrick)
            {
                ScoreManager.AddTrick(flea, ScoreManager.TrickType.WalkOnTightRope);
                DistanceTraveled -= DistanceWalkedPerTrick;
            }
        }
    }
}
