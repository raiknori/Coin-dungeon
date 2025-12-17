using System.Collections;
using TMPro;
using UnityEngine;
public class Ending:MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textTMP;
    [SerializeField] UIPanel textPanel;
    [SerializeField] string[] winLines;
    [SerializeField] string[] looseDebtLines;
    [SerializeField] string[] looseDeathLines;
    [SerializeField] GoldCore gold;
    [SerializeField] AudioManager audioManager;

    [SerializeField] Restart restart;

    string[] debtLines = 
    {
        "your debt was",
        "you earned...",
        "gold!",
    };
    public void StartDeathEnding()
    {
        StartCoroutine(DoEnding(looseDeathLines));
    }
    public void StartDebtEnding()
    {
        StartCoroutine(DoDebtEnding(looseDebtLines));
    }
    public void StartWinEnding()
    {
        StartCoroutine(DoDebtEnding(winLines));
    }

    IEnumerator DoDebtEnding(string[] lines)
    {
        textPanel.gameObject.SetActive(true);

        yield return StartCoroutine(DebtLines());
        yield return StartCoroutine(DoEnding(lines));
        
    }

    IEnumerator DebtLines()
    {
        debtLines[0] = $"{debtLines[0]} {gold.Debt}...";

        for(int i = 0; i < debtLines.Length; i++)
        {
            textPanel.FadeIn();

            if (i==debtLines.Length-1)
            {
                textTMP.text = $"{gold.Gold} {debtLines[i]}";

                yield return StartCoroutine(WaitForInput());
                textPanel.FadeOut();
                yield return new WaitForSeconds(textPanel.FadeDuration);
                yield break;
            }

            textTMP.text = debtLines[i];

            yield return StartCoroutine(WaitForInput());
            textPanel.FadeOut();
            yield return new WaitForSeconds(textPanel.FadeDuration / 3);
        }

 

        textPanel.FadeOut();
        yield return new WaitForSeconds(textPanel.FadeDuration / 3);

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

        restart.WaitForRestart();
    }

    [SerializeField] GameObject waitForInputText;
    IEnumerator WaitForInput()
    {
        waitForInputText?.SetActive(true);

        while (true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {

                audioManager.PlaySound("click");
                break;
            }

            yield return null;
        }

        waitForInputText?.SetActive(false);
    }

}
