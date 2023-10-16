<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<<< HEAD:Assets/Scripts/LevelSelector.cs
public class NewBehaviourScript : MonoBehaviour
========
public class MoveForward : MonoBehaviour
>>>>>>>> master:Assets/Scripts/MoveForward.cs
{
    // Start is called before the first frame update
    public float speed = 40.0f;

    void Start() { }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * (-speed));
    }
}
=======
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("main");
    }
}
>>>>>>> master
