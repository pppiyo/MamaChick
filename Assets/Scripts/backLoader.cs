using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backLoader : MonoBehaviour
{
    public void LoadStartMenuScene()
    {
        SceneManager.LoadScene("Start Menu");
    }
}

