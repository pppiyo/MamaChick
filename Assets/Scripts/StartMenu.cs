using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void LoadStartMenuScene()
    {
        SceneManager.LoadScene("StartMenu");
    }
}