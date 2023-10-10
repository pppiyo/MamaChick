using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialLoader : MonoBehaviour
{
    public void LoadTutorialScene()
    {
        SceneManager.LoadScene("tutorial");
    }
}
