using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class GameCore:MonoBehaviour
{
    bool gameStopped = true;
    [Inject] Grid grid;
    [Inject] FloorCore floors;
    [SerializeField] UIPanel transitionPanel;
    [SerializeField] GameObject healthText;
    [SerializeField] GameObject goldText;
    [SerializeField] GameObject goldXText;
    [Inject] Restart restart;
    [Inject] Ending ending;
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
        ending.StartWinEnding();

    }

    public void LooseGameDeath()
    {

        transitionPanel.FadeIn();
        gameStopped = true;
        healthText.SetActive(false);
        goldText.SetActive(false);
        goldXText.SetActive(false);
        ending.StartDeathEnding();
    }

    public void LooseGameDebt()
    {
        transitionPanel.FadeIn();
        gameStopped = true;
        healthText.SetActive(false);
        goldText.SetActive(false);
        goldXText.SetActive(false);
        ending.StartDebtEnding();
    }

    
    
}
