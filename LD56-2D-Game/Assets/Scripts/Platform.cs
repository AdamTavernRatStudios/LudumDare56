using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    bool IsBonusPlatform = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Flea"))
        {
            if(collision.relativeVelocity.y < 0f && collision.rigidbody.velocity.y == 0f)
            {
                if (IsBonusPlatform)
                {
                    ScoreManager.AddTrick(collision.gameObject.GetComponent<Flea>(), ScoreManager.TrickType.LandOnPlatform);
                }
                else
                {
                    ScoreManager.AddTrick(collision.gameObject.GetComponent<Flea>(), ScoreManager.TrickType.LandOnPlatform);
                }
            }
        }
    }
}
