using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float BubblePopBounceForce = 50f;
    public GameObject BubbleParticles;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var f = collision.gameObject.GetComponent<Flea>();
        if (f != null)
        {
            f.rb.velocity = new Vector3(f.rb.velocity.x, Mathf.Max(f.rb.velocity.y, BubblePopBounceForce));
            ScoreManager.AddTrick(f, ScoreManager.TrickType.BubbleBounce);
            var particles = Instantiate(BubbleParticles, transform.position, Quaternion.identity);
            Destroy(particles, 1f);
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        Destroy(this.gameObject, 10f);
    }
}
