using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource SourceA;
    public AudioSource SourceB;
    public AudioSource SourceC;
    public static MusicPlayer Instance;

    public AudioClip MainMenuMusic;
    public AudioClip BuildMenuMusic;
    public AudioClip FightMusic;

    public void PlayMainMenuMusic(){
        PlayMusic(MainMenuMusic);
        }
    public void PlayBuildMenuMusic(){ 
        PlayMusic(BuildMenuMusic);
            }
    public void PlayFightMusic()
    {
        PlayMusic(FightMusic);
    }

    private void Start()
    {
        TryPlaySceneMusic();
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        TryPlaySceneMusic();
    }

    private void TryPlaySceneMusic()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        var scenemusic = AudioManager.Instance.SceneMusics.Find((c) => c.SceneName == sceneName);
        if (scenemusic != null)
        {
            PlayMusic(scenemusic.Music);
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            this.transform.parent = null;
            DontDestroyOnLoad(gameObject);
            SourceA.Stop();
            SourceB.Stop();
            SourceC.Stop();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if(!SourceA.isPlaying && !SourceB.isPlaying && !SourceC.isPlaying)
        {
            SourceA.clip = clip;
            SourceA.volume = 1f;
            SourceA.Play();
            return;
        }

        if (SourceA.isPlaying)
        {
            SourceB.clip = clip;
            SourceB.volume = 0f;
            SourceB.Stop();
            SourceB.Play();
            SwitchSources(SourceA, SourceB, clip);
        }
        else if (SourceB.isPlaying)
        {
            SourceC.clip = clip;
            SourceC.volume = 0f;
            SourceC.Stop();
            SourceC.Play();
            SwitchSources(SourceB, SourceC, clip);
        }
        else
        {
            SourceA.clip = clip;
            SourceA.volume = 0f;
            SourceA.Stop();
            SourceA.Play();
            SwitchSources(SourceC, SourceA, clip);
        }
    }

    void SwitchSources(AudioSource TurnMeOff, AudioSource TurnMeOn, AudioClip c = null)
    {
        float v = 1f;
        if (c == FightMusic) v = 0.4f;
        LeanTween.value(0f, 1f, 0.25f).setOnUpdate((float f) =>
        {
            TurnMeOff.volume = 1 - f;
            TurnMeOn.volume = f;
        }).setOnComplete(() =>
        {
            TurnMeOff.volume = 0f;
            TurnMeOn.volume = v;
            TurnMeOff.Stop();
        });
    }

    public void PlayMusic(AudioClip c1, AudioClip c2, AudioClip c3)
    {
        if (c1 != null)
        {
            SourceA.clip = c1;
            SourceA.volume = 1f;
            SourceA.Play();
        }
        else
        {
            SourceA.Stop();
        }

        if (c2 != null)
        {
            SourceB.clip = c2;
            SourceB.volume = 0f;
            SourceB.Play();
        }
        else
        {
            SourceB.Stop();
        }

        if (c3 != null)
        {
            SourceC.clip = c3;
            SourceC.volume = 0f;
            SourceC.Play();
        }
        else
        {
            SourceC.Stop();
        }
    }

    public void SwitchLayer()
    {
        AudioSource TurnMeOn = null;
        AudioSource TurnMeOff = null;
        if (SourceA.volume != 0f)
        {
            TurnMeOff = SourceA;
            TurnMeOn = SourceB;
        }
        else if (SourceB.volume != 0f)
        {
            TurnMeOff = SourceB;
            TurnMeOn = SourceC;
        }
        else if (SourceC.volume != 0f)
        {
            TurnMeOff = SourceC;
            TurnMeOn = SourceA;
        }


        SwitchSources(TurnMeOff, TurnMeOn);
   
    }
}
