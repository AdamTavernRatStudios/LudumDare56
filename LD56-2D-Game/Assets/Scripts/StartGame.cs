using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
    public void LoadInstructions()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Instructions");
    }
}
