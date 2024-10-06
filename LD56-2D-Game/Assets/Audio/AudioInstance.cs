using UnityEngine;

public class AudioInstance : MonoBehaviour
{

    float unpausedVolume = 0f;

    public AudioSource AS;

    public DestroyMe destroyMe = null;

    public void FadeInOut(float duration, float fadeTime = 0.2f)
    {
        AS = GetComponent<AudioSource>();
        if (duration >= fadeTime * 2f)
        {
            fadeTime = duration / 2f;
        }
        if (AS == null)
        {
            return;
        }
        var maxVol = AS.volume;
        LeanTween.cancel(gameObject);
        LeanTween.value(gameObject, 0f, maxVol, fadeTime).setOnUpdate((float f) =>
        {
            if (AS != null)
            {
                AS.volume = f;
            }
        }).setOnComplete(() =>
        {
            if (AS != null)
            {
                AS.volume = maxVol;
            }
        });

        LeanTween.value(gameObject, maxVol, 0f, fadeTime).setDelay(duration - fadeTime).setOnUpdate((float f) =>
        {
            if (AS != null)
            {
                AS.volume = f;
            }
        }).setOnComplete(() =>
        {
            if (AS != null)
            {
                AS.volume = 0f;
            }
        });
    }

    public void FadeIn(float duration, float vol = -1f)
    {
        if (AS == null)
        {
            return;
        }
        LeanTween.cancel(gameObject);
        var finalVol = AS.volume;
        if(vol > 0f)
        {
            finalVol = vol;
        }
        LeanTween.value(gameObject, 0, finalVol, duration).setOnUpdate((float f) =>
        {
            if (AS != null)
            {
                AS.volume = f;
            }
        }).setOnComplete(() =>
        {
            if (AS != null)
            {
                AS.volume = finalVol;
            }
        });
    }

    public void FadeOut(float duration, float vol = -1f)
    {
        if (AS == null)
        {
            return;
        }
        LeanTween.cancel(gameObject);
        var startVol = AS.volume;
        if (vol > 0f)
        {
            startVol = vol;
        }
        LeanTween.value(gameObject, startVol, 0f, duration).setOnUpdate((float f) =>
        {
            if (AS != null)
            {
                AS.volume = f;
            }
        }).setOnComplete(() =>
        {
            if (AS != null)
            {
                AS.volume = 0f;
            }
        });
    }
}
