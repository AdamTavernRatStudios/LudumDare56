using Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Serializable]
    public class SceneAndMusic
    {
        public string SceneName;
        public AudioClip Music;
        public AudioClip MusicLayer2;
        public AudioClip MusicLayer3;
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.parent = null;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        ParseIntoDictionary();

        if (MusicPlayer.Instance == null)
        {
            Instantiate(musicPlayer);
        }
    }

    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) GetClip(string name)
    {
        return GetClipData(name);
    }

    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) GetClipData(string name)
    {
        if (Instance == null)
        {
            Debug.LogWarning("No instance of audio manager found");
            return (null, null);
        }
        if (Instance.AudioClips == null)
        {
            Debug.LogWarning("Audio manager does not have an AudioClipsContainerScriptableObjectAssigned");
            return (null, null);
        }
        if (!Instance.ParsingComplete)
        {
            Debug.LogWarning("Parsing audio clips incomplete, searching list slowly");
            var clip = Instance.AudioClips.AudioClipsData.Find((clip) => clip.name == name);
            return (clip, clip.GetComponent<AudioDataCustomOverrides>());
        }
        if (Instance.AudioClipsDict.ContainsKey(name))
        {
            return Instance.AudioClipsDict[name];
        }
        if (Clips.clipDict.ContainsKey(name))
        {
            return Clips.clipDict[name];
        }
        return (null, null);
    }

    public class AudioInstanceData
    {
        public string name = string.Empty;

        public bool Loop = false;
        public float LoopDuration = 1f;
        public Func<bool> LoopEndCondition = null;

        public bool UseRandomizedData = false;

        public AudioSource audioSourceData = null;
        public AudioDataCustomOverrides customOverrides = null;

        public AudioInstanceData()
        {
        }

        public AudioInstanceData(string name)
        {
            this.UpdateWithAudioSource(GetClip(name));
        }
        public AudioInstanceData(AudioClip clip)
        {
            this.UpdateWithAudioSource(GetClip(clip.name));
        }

        public AudioInstanceData(AudioSource AS)
        {
            UpdateWithAudioSource(AS);
        }

        public AudioInstanceData((AudioSource audioSource, AudioDataCustomOverrides overrides) data)
        {
            UpdateWithAudioSource(data);
        }

        public void UpdateWithAudioSource(AudioSource AS)
        {
            UpdateWithAudioSource(GetClip(AS.clip.name));
        }

        private void UpdateWithAudioSource((AudioSource audioSource, AudioDataCustomOverrides overrides) data)
        {
            if(data.audioSource == null || data.overrides == null)
            {
                Debug.Log("Audiosource not found");
                return;
            }
            this.name = data.audioSource.clip.name;
            this.audioSourceData = data.audioSource;
            this.customOverrides = data.overrides;
        }

    }

    public static AudioInstanceData GenericRandomizedData
    {
        get
        {
            return new AudioInstanceData()
            {
                UseRandomizedData = true
            };
        }
    }

    public static AudioSource LoopClip((AudioSource, AudioDataCustomOverrides) data, float duration)
    {
        return PlayClip(new AudioInstanceData(data.Item1)
        {
            LoopDuration = duration
        });
    }

    public static void PlayClipWithDelay((AudioSource, AudioDataCustomOverrides) data, float delay)
    {
        PlayClipWithDelay(new AudioInstanceData(data.Item1), delay);
    }

    public static void PlayClipWithDelay((AudioSource, AudioDataCustomOverrides) clip, AudioInstanceData data, float delay)
    {
        data.UpdateWithAudioSource(clip.Item1);
        PlayClipWithDelay(data, delay);
    }

    private static void PlayClipWithDelay(AudioInstanceData data, float delay)
    {
        Instance?.StartCoroutine(PlayClipWithDelayRoutine(delay, data));
    }

    private static IEnumerator PlayClipWithDelayRoutine(float time, AudioInstanceData data)
    {
        yield return new WaitForSeconds(time);
        PlayClip(data);
    }

    public static AudioSource PlayClip(string name)
    {
        return PlayClip(new AudioInstanceData(name));
    }

    public static AudioSource PlayClip((AudioSource, AudioDataCustomOverrides) data)
    {
        return PlayClip(new AudioInstanceData(data));
    }

    public static AudioSource PlayClip((AudioSource, AudioDataCustomOverrides) ASData, AudioInstanceData data)
    {
        return PlayClip(ASData.Item1, data);
    }

    public static AudioSource PlayClip(AudioSource AS)
    {
        if(AS == null)
        {
            return null;
        }
        return PlayClip(new AudioInstanceData(AS));
    }

    public static AudioSource PlayClip(AudioClip clip)
    {
        return PlayClip(new AudioInstanceData(clip));
    }

    public static AudioSource PlayClip(AudioSource AS, AudioInstanceData data)
    {
        if (AS == null || AS.clip.name == "")
        {
            return null;
        }
        data.UpdateWithAudioSource(AS);
        return PlayClip(data);
    }

    public static AudioSource PlayClip(string name, AudioInstanceData data)
    {
        return PlayClip(GetClip(name).audioSource, data);
    }

    public static AudioSource PlayUIBlip()
    {
        return PlayClip(Clips.ui_blip);
    }

    public static AudioSource PlayUIBlipNegative()
    {
        return PlayClip(Clips.ui_blip_negative);
    }

    // All public methods should funnel into here
    private static AudioSource PlayClip(AudioInstanceData data)
    {
        if(data.audioSourceData == null || data.customOverrides == null || data.name == string.Empty)
        {
            return null;
        }
        if (data.audioSourceData.clip == null && data.name != string.Empty)
        {
            data.audioSourceData.clip = GetClip(data.name).audioSource?.clip;
        }
        if (data.audioSourceData == null || data.audioSourceData.clip == null)
        {
            Debug.LogWarning("Audio clip you wanted to play is null");
            return null;
        }
        var newAudioInstance = ObjectPool.Instance?.Instantiate("AudioInstance");
        if(newAudioInstance == null)
        {
            return null;
        }
        var audioInstance = newAudioInstance.GetComponent<AudioInstance>();
        var AS = audioInstance.AS;
        AS.clip = data.audioSourceData.clip;
        AS.volume = data.audioSourceData.volume;
        if (data.customOverrides.UseRandomizedVolume || data.UseRandomizedData)
        {
            AS.volume = UnityEngine.Random.Range(data.customOverrides.MinVolume, data.customOverrides.MaxVolume);
        }
        AS.pitch = data.audioSourceData.pitch;
        if (data.customOverrides.UseRandomizedPitch || data.UseRandomizedData)
        {
            AS.pitch = UnityEngine.Random.Range(data.customOverrides.MinPitch, data.customOverrides.MaxPitch);
        }
        AS.playOnAwake = data.audioSourceData.playOnAwake;

        // If we called this to loop from code, we ensure that the overrides component is also set to loop
        if (data.Loop)
        {
            data.customOverrides.Loop = true;
            data.customOverrides.LoopDuration = data.LoopDuration;
        }

        AS.loop = data.customOverrides.Loop;

        AS.outputAudioMixerGroup = Instance?.SFXMixer;

        if (data.audioSourceData.playOnAwake)
        {
            AS.Play();
        }

        if(data.LoopEndCondition == null)
        {
            var actualDuration = (AS.clip.length / AS.pitch) * 1.1f;
            audioInstance.destroyMe.destroy(AS.loop ? data.customOverrides.LoopDuration : actualDuration);
            if (data.customOverrides.Loop)
            {
                audioInstance.FadeInOut(data.customOverrides.LoopDuration);
            }
        }
        else
        {
            audioInstance
                .StartCoroutine(Instance.DestroyAfterCondition(newAudioInstance, data.LoopEndCondition));
        }

        return AS;
    }

    public IEnumerator DestroyAfterCondition(GameObject AudioInstance, Func<bool> endCondition)
    {
        var audioInstance = AudioInstance.GetComponent<AudioInstance>();
        audioInstance.FadeIn(0.1f);
        yield return new WaitUntil(endCondition);
        audioInstance.FadeOut(0.1f);
        audioInstance.destroyMe.destroy(0.1f);
    }

    bool ParsingComplete = false;
    public void ParseIntoDictionary()
    {
        foreach (var clip in AudioClips.AudioClipsData)
        {
            var val = (clip, clip.GetComponent<AudioDataCustomOverrides>());
            var name = new string(clip.name.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
            var fixedName = name.Replace('-', '_');
            AudioClipsDict[name] = val;
            AudioClipsDict[fixedName] = val;
        }
        ParsingComplete = true;
    }

    public void SwitchToBossDefeatMusic()
    {
        MusicPlayer.Instance.PlayMusic(BossDefeatMusic);
    }


    Dictionary<string, (AudioSource, AudioDataCustomOverrides)> AudioClipsDict = new();
    public AudioClipsContainer AudioClips;
    public AudioMixerGroup SFXMixer;
    public AudioMixerGroup MusicMixer;

    public MusicPlayer musicPlayer;

    public List<SceneAndMusic> SceneMusics;
    public AudioClip BossDefeatMusic;
}
