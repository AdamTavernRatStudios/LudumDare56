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
        if (collision.gameObject.layer == LayerMask.NameToLayer("Flea"))
        {
            if (collision.relativeVelocity.y < 0f && collision.rigidbody.velocity.y == 0f)
            {
                var f = collision.gameObject.GetComponent<Flea>();
                if(f != null)
                {
                    ScoreManager.AddTrick(f, ScoreManager.TrickType.TrampolineBounce);
                    f.rb.velocity = new Vector2(f.rb.velocity.x, BounceHeight);
                    anim.SetTrigger("Bounce");
                }
            }
        }
    }
}
