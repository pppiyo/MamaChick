using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("main");
    }
}