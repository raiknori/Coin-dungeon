using System.Collections;
using UnityEngine;
using Zenject;

public class Restart:MonoBehaviour
{
    [Inject] GameCore game;
    [SerializeField] UIPanel transitionPanel;
    [Inject] AudioManager audioManager;
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

                audioManager.PlaySound("click");
                break;
            }


            yield return null;
        }

        restartText.SetActive(false);

        game.NewGame();

    }
}
