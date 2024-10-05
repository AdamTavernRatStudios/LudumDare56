using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleaAnimatorManager : MonoBehaviour
{
    Flea flea;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        flea = GetComponentInParent<Flea>();
        anim = GetComponent<Animator>();
        flea.Twirl.AddListener(DoTwirl);
    }

    private void OnDisable()
    {
        flea.Twirl.RemoveListener(DoTwirl);
    }

    private void DoTwirl()
    {
        anim.SetTrigger("Twirl");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        anim.SetFloat("MovementSpeed", flea.TouchingGround ? Mathf.Abs(flea.rb.velocity.x) : 0f);
        anim.SetBool("TouchingGround", flea.TouchingGround);
    }
}
