using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance { get; private set; }
    public Animator anim;
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


    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadLevelRoutine(levelName));
    }

    bool Loading = false;
    IEnumerator LoadLevelRoutine(string levelName)
    {
        if (Loading) yield break;
        Loading = true;
        anim.SetTrigger("Enter");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelName);
        anim.SetTrigger("Exit");
        yield return new WaitForSeconds(1f);
        Loading = false;
    }
}
