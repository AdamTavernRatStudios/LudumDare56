using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamingHoop : MonoBehaviour
{
    public CollisionListener collisionListener;


    // Start is called before the first frame update
    void Start()
    {
        collisionListener.TriggerEnter2D.AddListener(HandleOnTrigger);
    }

    private void OnDisable()
    {
        collisionListener.TriggerEnter2D.RemoveListener(HandleOnTrigger);
    }

    private void HandleOnTrigger(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Flea"))
        {
            var flea = other.gameObject.GetComponent<Flea>();
            ScoreManager.AddTrick(flea, ScoreManager.TrickType.JumpThroughHoop);
        }
    }
}
