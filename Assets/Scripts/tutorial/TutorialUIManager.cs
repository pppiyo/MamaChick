using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialUIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private Button nextButton;
    [SerializeField] private Text buttonText;
    [SerializeField] private string[] textBatches;
    [SerializeField] private GameObject arrow; // Reference to the arrow GameObject
    [SerializeField] private GameObject[] objectsToReference; // Reference to objects in the scene
    [SerializeField] private float arrowYOffset = 2.0f; // New variable for the Y-axis offset
    [SerializeField] private Camera mainCamera;

    public GameObject eagle;

    private float EAGLE_LIMIT_UP = 100;
    private float EAGLE_LIMIT_DOWN = 65;
    private float EAGLE_LIMIT_LEFT = 300;
    private float EAGLE_LIMIT_RIGHT = 100;

    private int currentBatch = 0;

    private void Start()
    {
        nextButton.onClick.AddListener(ShowNextBatch);
        ShowBatch(0);
    }

    private void ShowBatch(int batchIndex)
    {
        // Debug.Log(textBatches.Length);
        if (batchIndex < 0 || batchIndex >= textBatches.Length) return;

        displayText.text = textBatches[batchIndex];

        // Control arrow visibility and position based on currentBatch
        if (batchIndex >= 0 && batchIndex < objectsToReference.Length)
        {
            SetArrowPosition(objectsToReference[batchIndex].transform.position);
        }
        else
        {
            arrow.SetActive(false); // Hide the arrow
        }

        // if (batchIndex == 6)
        // {
        //     // spawn eagle
        //     SpawnRandomEagle();
        // }

        // 如果这是最后一批文字，更改按钮的文本
        if (batchIndex == textBatches.Length - 1)
        {
            buttonText.text = "Have Fun!";
        }
    }

    private void ShowNextBatch()
    {
        currentBatch++;
        if (currentBatch < textBatches.Length)
        {
            ShowBatch(currentBatch);
        }
        else
        {
            EndTutorial();
        }
    }

    private void EndTutorial()
    {
        nextButton.gameObject.SetActive(false); // Hide the button
        displayText.gameObject.SetActive(false); // Hide the text
        arrow.SetActive(false); // Hide the arrow
    }

    private void SpawnRandomEagle()
    {
        float y = Random.Range(EAGLE_LIMIT_DOWN, EAGLE_LIMIT_UP);
        float z = Random.Range(EAGLE_LIMIT_LEFT, EAGLE_LIMIT_RIGHT);
        Vector3 spawnPos = new Vector3(0, y, z);
        Instantiate(eagle, spawnPos, eagle.transform.rotation);
    }

    private void SetArrowPosition(Vector3 referenceObjectPosition)
    {
        arrow.SetActive(true);
    
        // Convert the 3D object's world position to screen position
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(referenceObjectPosition);
    
        // Convert the screen position to canvas position
        Vector2 canvasPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(arrow.transform.parent.GetComponent<RectTransform>(), screenPosition, mainCamera, out canvasPosition);
    
        // Set the arrow's position to be slightly above the object's position
        canvasPosition.y += 30;  // 50 is just an example offset, adjust as needed
    
        arrow.GetComponent<RectTransform>().anchoredPosition = canvasPosition;
    }

}
