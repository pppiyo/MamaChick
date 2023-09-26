using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // 引入TextMeshPro的命名空间

public class UpdateHPText : MonoBehaviour
{
    public cubeHealth health;
    public chickMP MP;
    private TextMeshProUGUI hpTextMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<cubeHealth>();
        hpTextMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        hpTextMeshPro.text = "";
        if (health != null)
        {
            hpTextMeshPro.text += "HP: " + health.curHP.ToString() + "\n";
        }
        if (MP != null)
        {
            hpTextMeshPro.text += "MP: " + MP.mp.ToString();
        }
    }
}
