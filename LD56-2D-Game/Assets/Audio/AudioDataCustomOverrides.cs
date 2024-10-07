using Unity.VisualScripting;
using UnityEngine;

public class AudioDataCustomOverrides : MonoBehaviour
{
    public bool ApplyOnStart = false;

    [Header("Volume Override")]
    public bool UseRandomizedVolume = false;
    public float MinVolume = 0.4f;
    public float MaxVolume = 0.6f;

    [Header("Pitch Override")]
    public bool UseRandomizedPitch = false;
    public float MinPitch = 0.8f;
    public float MaxPitch = 1.2f;

    [Header("Looping data")]
    public bool Loop = false;
    public float LoopDuration = 0f;

    private void Start()
    {
        if (ApplyOnStart)
        {
            var AS = GetComponent<AudioSource>();
            if (UseRandomizedVolume)
            {
                AS.volume = UnityEngine.Random.Range(MinVolume, MaxVolume);
            }
            if (UseRandomizedPitch)
            {
                AS.pitch = UnityEngine.Random.Range(MinPitch, MaxPitch);
            }
        }
    }
}
