using TMPro;
using UnityEngine;
using System.Collections;
public class Ending:MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textTMP;
    [SerializeField] UIPanel textPanel;
    [SerializeField] string[] winLines;
    [SerializeField] string[] looseDebtLines;
    [SerializeField] string[] looseDeathLines;

    public void StartDeathEnding()
    {
        StartCoroutine(DoEnding(looseDeathLines));
    }
    public void StartDebtEnding()
    {
        StartCoroutine(DoEnding(looseDebtLines));
    }
    public void StartWinEnding()
    {
        StartCoroutine(DoEnding(winLines));
    }

    IEnumerator DoEnding(string[] lines)
    {
        textPanel.gameObject.SetActive(true);

        foreach (string line in lines)
        {

            textTMP.text = line;
            textPanel.FadeIn();
            yield return StartCoroutine(WaitForInput());
            textPanel.FadeOut();
            yield return new WaitForSeconds(textPanel.FadeDuration / 3);
        }

        textPanel.gameObject.SetActive(false);
    }

    [SerializeField] GameObject waitForInputText;
    IEnumerator WaitForInput()
    {
        waitForInputText?.SetActive(true);

        while (true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                break;
            }

            yield return null;
        }

        waitForInputText?.SetActive(false);
    }

}
