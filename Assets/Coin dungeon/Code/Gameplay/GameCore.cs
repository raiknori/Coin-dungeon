using UnityEngine;
using UnityEngine.UIElements;

public class GameCore:MonoBehaviour
{
    bool gameStopped = true;
    [SerializeField] Grid grid;
    [SerializeField] FloorCore floors;
    [SerializeField] UIPanel transitionPanel;
    [SerializeField] GameObject healthText;
    [SerializeField] GameObject goldText;
    [SerializeField] GameObject goldXText;
    [SerializeField] Restart restart;
    [SerializeField] Ending ending;
    public bool GameStopped
    {
        get { return gameStopped; } 

        set { gameStopped = value; }
    }

    public void NewGame()
    {
        
        gameStopped = false;
        floors.ClearFloor();
        floors.FirstFloor();
        transitionPanel.FadeOut();
        healthText.SetActive(true);
        goldText.SetActive(true);
        goldXText.SetActive(true);

    }

    public void WinGame()
    {
        transitionPanel.FadeIn();
        gameStopped = true;
        healthText.SetActive(false);
        goldText.SetActive(false);
        goldXText.SetActive(false);
        restart.WaitForRestart();
        ending.StartWinEnding();

    }

    public void LooseGameDeath()
    {

        transitionPanel.FadeIn();
        gameStopped = true;
        healthText.SetActive(false);
        goldText.SetActive(false);
        goldXText.SetActive(false);
        restart.WaitForRestart();
        ending.StartDeathEnding();
    }

    public void LooseGameDebt()
    {
        transitionPanel.FadeIn();
        gameStopped = true;
        healthText.SetActive(false);
        goldText.SetActive(false);
        goldXText.SetActive(false);
        restart.WaitForRestart();
        ending.StartDebtEnding();
    }

    
    
}
