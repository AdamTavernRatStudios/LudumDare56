using UnityEngine;

public class AudioDataCustomOverrides : MonoBehaviour
{
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
}
