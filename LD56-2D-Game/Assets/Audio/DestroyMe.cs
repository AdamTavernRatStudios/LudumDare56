using System.Collections;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    public float TimeToDestroy = -1f;
    public bool PooledObject = false;
    void Start()
    {
        if (TimeToDestroy < 0)
        {
            return;
        }
        StartCoroutine(DestroyWithDelay());
    }

    public void destroy(float time)
    {
        TimeToDestroy = time;
        StartCoroutine(DestroyWithDelay());
    }

    bool Destroying = false;
    IEnumerator DestroyWithDelay()
    {
        if (Destroying)
        {
            yield break;
        }
        Destroying = true;
        yield return new WaitForSecondsRealtime(TimeToDestroy);
        if (PooledObject)
        {
            Destroying = false;
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
