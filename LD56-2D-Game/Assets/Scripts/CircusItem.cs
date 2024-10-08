using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircusItem : MonoBehaviour
{
    public bool Occupied => flea != null;
    public Flea flea;
    public bool HidePlayerWhenOccupied = false;
    public bool MakePlayerKinematic = false;
    public float ResetTime = 0.5f;

    bool Resetting = false;
    public bool TryAddPlayer(Flea f)
    {
        if (f != null && !f.InCircusItem && !Resetting)
        {
            flea = f;
            flea.activeCircusItem = this;
            if (HidePlayerWhenOccupied)
            {
                flea.rb.isKinematic = true;
                flea.transform.position = new Vector3(0, 500, 0);
                flea.coll.enabled = false;
            }
            if (MakePlayerKinematic)
            {
                flea.rb.isKinematic = true;
                flea.coll.enabled = false;
            }
            return true;
        }
        return false;
    }

    public Flea RemovePlayer()
    {
        if (flea == null) return null;
        var temp = flea;
        if (HidePlayerWhenOccupied)
        {
            flea.rb.isKinematic = false;
            flea.transform.position = transform.position;
            flea.coll.enabled = true;
        }
        if (MakePlayerKinematic)
        {
            flea.rb.isKinematic = false;
            flea.coll.enabled = true;
        }
        flea.activeCircusItem = null;
        flea = null;
        if(interactionRoutine != null)
        {
            StopCoroutine(interactionRoutine);
        }
        StartCoroutine(ResetCouroutine(ResetTime));
        return temp;
    }

    private void FixedUpdate()
    {
        if(flea != null)
        {
            if (flea.currentFrameInput.JumpJustPressed)
            {
                DoInteraction();
            }
        }
    }

    public virtual void DoInteraction()
    {

    }

    IEnumerator ResetCouroutine(float resetTime)
    {
        Resetting = true;
        yield return new WaitForSeconds(resetTime);
        Resetting = false;
    }

    public IEnumerator interactionRoutine = null;
    public void DoInteractionOnDelay(float timeout)
    {
        if(interactionRoutine != null)
        {
            StopCoroutine(interactionRoutine);
        }
        interactionRoutine = DoInteractionRoutine(timeout);
        StartCoroutine(interactionRoutine);
    }
    private IEnumerator DoInteractionRoutine(float timeout)
    {
        yield return new WaitForSeconds(timeout);
        DoInteraction();
    }
}
