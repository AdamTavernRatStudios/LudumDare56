
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AudioClipContainerScriptableObject", order = 3)]

public class AudioClipsContainer : ScriptableObject
{
    public List<AudioSource> AudioClipsData;
}

