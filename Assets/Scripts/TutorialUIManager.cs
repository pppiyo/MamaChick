using UnityEngine;
using UnityEngine.UI;
using TMPro;


/*
 *
 1. This is the chick that you're gonna feed
 2. Chick's hp will decrease as time goes by
 3. When hp drops to 0, the chick disappears and no points will be gained through this chick
 4. You can pick up any worm on the ground to feed the chick
 5. You will gain 1 point by feeding a chick with exactly 21 magic points of apples
 6. Your goal is to gain as many points as possible in 5 minutes
 7. There will be randomly spawned eagles catching chicken, you can throw pebble to hit them down
 
 1. Press '<-' and '->' (or 'A' and 'D') to control the movement of Mama
 2. Press 'Ctrl' to pick up a pebble or worm
 3. Hold your mouse down and drag the pebble/worm to adjust your spring and angles
 4. Release the mouse to throw the object
 5. Let's start!
 */
public class TutorialUIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private Button nextButton;
    [SerializeField] private Text buttonText;
    [SerializeField] private string[] textBatches;

    private int currentBatch = 0;

    private void Start()
    {
        nextButton.onClick.AddListener(ShowNextBatch);
        ShowBatch(0);
    }

    private void ShowBatch(int batchIndex)
    {
        if (batchIndex < 0 || batchIndex >= textBatches.Length) return;

        displayText.text = textBatches[batchIndex];

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
        nextButton.gameObject.SetActive(false); // 隐藏按钮
        displayText.gameObject.SetActive(false); // 隐藏文本
        // backgroundPanel.SetActive(false); // 隐藏背景遮罩
        //
        // Time.timeScale = 1;
        // Time.fixedDeltaTime = 0.02f;  // 重置fixedDeltaTime
    }
}