using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void LoadLevelSelectionScene()
    {
        SceneManager.LoadScene("LevelSelectionScene");
    }
}
