using UnityEngine;
using UnityEditor;

public class ExampleWindow : EditorWindow
{
    Color color;

    [MenuItem("Window/Colorizer")]
    public static void ShowWindow()
    {
        GetWindow<ExampleWindow>("Colorizer");
    }

    void OnGUI()
    {
        // Window code
        GUILayout.Label("Color the selected objects!", EditorStyles.boldLabel); // Use GUILayout for labels, spaces between properties and buttons

        color = EditorGUILayout.ColorField("Color", color); // Use EditorGUILayout for fields and property

        if (GUILayout.Button("Colorize!"))
        {
            Colorize();
        }
    }

    private void Colorize()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();

            if (renderer != null)
            {
                renderer.sharedMaterial.color = color;
            }
        }
    }
}
