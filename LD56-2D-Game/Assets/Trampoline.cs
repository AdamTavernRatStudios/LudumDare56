using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float BounceHeight = 10f;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("oy3");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Flea"))
        {
            Debug.Log("oy2");
            Debug.Log(collision.relativeVelocity.y);
            Debug.Log(collision.rigidbody.velocity.y);
            if (collision.relativeVelocity.y < 0f && collision.rigidbody.velocity.y < 0.1f && collision.rigidbody.velocity.y > -0.1f)
            {
                var f = collision.gameObject.GetComponent<Flea>();
                Debug.Log("oy1");
                if (f != null)
                {
                    Debug.Log("oy");
                    ScoreManager.AddTrick(f, ScoreManager.TrickType.TrampolineBounce);
                    f.rb.velocity = new Vector2(f.rb.velocity.x, BounceHeight);
                    anim.SetTrigger("Bounce");
                }
            }
        }
    }
}
