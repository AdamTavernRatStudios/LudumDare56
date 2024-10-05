using System;
using UnityEngine;
using UnityEngine.Events;

public class CollisionListener : MonoBehaviour
{
    // A generic class that can be used so that a different component can subscribe to multiple colliders' collison or trigger events
    public UnityEvent<Collision2D> CollisionEnter2D = new();
    public UnityEvent<Collision2D> CollisionStay2D = new();
    public UnityEvent<Collision2D> CollisionExit2D = new();
    public UnityEvent<Collider2D> TriggerEnter2D = new();
    public UnityEvent<Collider2D> TriggerStay2D = new();
    public UnityEvent<Collider2D> TriggerExit2D = new();

    private void OnCollisionEnter2D(Collision2D Collision2D)
    {
        CollisionEnter2D?.Invoke(Collision2D);
    }

    private void OnCollisionStay2D(Collision2D Collision2D)
    {
        CollisionStay2D?.Invoke(Collision2D);
    }

    private void OnCollisionExit2D(Collision2D Collision2D)
    {
        CollisionExit2D?.Invoke(Collision2D);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        TriggerEnter2D?.Invoke(collider);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        TriggerStay2D?.Invoke(collider);
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        TriggerExit2D?.Invoke(collider);
    }

}
