using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void LoadGame()
    {
        LevelLoader.Instance.LoadLevel("Game");
    }
    public void LoadInstructions()
    {
        LevelLoader.Instance.LoadLevel("Instructions");
    }
}
