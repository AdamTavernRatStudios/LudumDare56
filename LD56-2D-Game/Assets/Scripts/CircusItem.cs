using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircusItem : MonoBehaviour
{
    public bool Occupied => flea != null;
    public Flea flea;
    public bool HidePlayerWhenOccupied = false;
    public void AddPlayer(Flea f)
    {
        if (f != null)
        {
            flea = f;
            if (HidePlayerWhenOccupied)
            {
                flea.rb.isKinematic = true;
                flea.transform.position = new Vector3(0, -200, 0);
            }
        }
    }

    public Flea RemovePlayer()
    {
        var temp = flea;
        if (HidePlayerWhenOccupied)
        {
            flea.rb.isKinematic = false;
            flea.transform.position = transform.position;
        }
        flea = null;
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

    public IEnumerator DoInteractionRoutine(float timeout)
    {
        yield return new WaitForSeconds(timeout);
        DoInteraction();
    }
}
