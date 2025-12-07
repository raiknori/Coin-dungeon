using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StoryCore:MonoBehaviour
{
    [SerializeField] GameCore game;
    [SerializeField] TextMeshProUGUI textTMP;
    [SerializeField] UIPanel textPanel;
    [SerializeField] string[] storyLines;


    private void Start()
    {
        StartStory();
    }
    public void StartStory()
    {
        StartCoroutine(DoStory());
    }

    IEnumerator DoStory()
    {
        textPanel.gameObject.SetActive(true);

        foreach (var storyLine in storyLines)
        {

            textTMP.text = storyLine;
            textPanel.FadeIn();
            yield return StartCoroutine(WaitForInput());
            textPanel.FadeOut();
            yield return new WaitForSeconds(textPanel.FadeDuration/3);
        }

        textPanel.gameObject.SetActive(false);
        game.NewGame();
    }

    [SerializeField] GameObject waitForInputText;
    IEnumerator WaitForInput()
    {
        waitForInputText?.SetActive(true);

        while (true)
        {
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                break;
            }

            yield return null;
        }

        waitForInputText?.SetActive(false);
    }
}
