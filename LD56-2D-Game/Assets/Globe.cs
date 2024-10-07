using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globe : CircusItem
{
    public Transform Shading;
    public float SecondsPerTrickEarned = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Occupied)
        {
            if (TryAddPlayer(collision.gameObject.GetComponent<Flea>()))
            {
                ScoreManager.AddTrick(flea, ScoreManager.TrickType.EnterGlobe);
                TimeSpentOnGlobe = 0f;
                AudioManager.PlayClip(Audio.Clips.HopOnOffBall, AudioManager.GenericRandomizedData);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var f = collision.gameObject.GetComponent<Flea>();
        if (Occupied && f == flea)
        {
            ScoreManager.AddTrick(flea, ScoreManager.TrickType.ExitGlobe);
            RemovePlayer();
            AudioManager.PlayClip(Audio.Clips.HopOnOffBall, AudioManager.GenericRandomizedData);
        }
    }

    float TimeSpentOnGlobe = 0;
    private void FixedUpdate()
    {
        if (Occupied)
        {
            TimeSpentOnGlobe += Time.fixedDeltaTime;
            if(TimeSpentOnGlobe > SecondsPerTrickEarned)
            {
                ScoreManager.AddTrick(flea, ScoreManager.TrickType.WalkOnGlobe);
                TimeSpentOnGlobe -= SecondsPerTrickEarned;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Shading.transform.rotation = Quaternion.identity;
    }
}
