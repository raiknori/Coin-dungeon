using System.Collections;
using UnityEngine;

public class Restart:MonoBehaviour
{
    [SerializeField] GameCore game;
    [SerializeField] UIPanel transitionPanel;
    public void WaitForRestart()
    {
        StartCoroutine(Restarting());
    }

    [SerializeField] GameObject restartText;
    IEnumerator Restarting()
    {
        yield return new WaitForSeconds(transitionPanel.FadeDuration*1.5f);

        restartText.SetActive(true);

        while (true)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                break;
            }


            yield return null;
        }

        restartText.SetActive(false);

        game.NewGame();

    }
}
