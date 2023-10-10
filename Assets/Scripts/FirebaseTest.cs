using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class FirebaseTest : MonoBehaviour
{
    public Text text;

    [DllImport("__Internal")]
    public static extern void GetJSON(
        string path,
        string objectName,
        string callback,
        string fallback
    );

    // Start is called before the first frame update
    void Start()
    {
        GetJSON("example", gameObject.name, "OnRequestSuccess", "OnRequestFailed");
    }

    private void OnRequestSuccess(string data)
    {
        Debug.Log("OnRequestSuccess: " + data);
        text.color = Color.green;
        text.text = data;
    }

    private void OnRequestFailed(string data)
    {
        Debug.Log("OnRequestFailed: " + data);
        text.color = Color.red;
        text.text = data;
    }

    // Update is called once per frame
    void Update() { }
}
