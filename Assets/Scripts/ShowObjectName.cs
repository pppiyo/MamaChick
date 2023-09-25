using UnityEngine;
using UnityEngine.UI;

public class ShowObjectName : MonoBehaviour
{
    public Text nameText; // Reference to the Text UI element

    void Start()
    {
        // Check if a Text UI element is assigned
        if (nameText != null)
        {
            // Set the Text to display the GameObject's name
            nameText.text = gameObject.name;
        }
        else
        {
            Debug.LogWarning("Text UI element not assigned to ShowObjectName script on " + gameObject.name);
        }
    }
}
