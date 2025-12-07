using UnityEngine;
using UnityEngine.UIElements;

public class GameCore:MonoBehaviour
{
    bool gameStopped = true;
    [SerializeField] Grid grid;
    [SerializeField] FloorCore floors;
    [SerializeField] UIPanel transitionPanel;
    [SerializeField] GameObject healthText;
    [SerializeField] Restart restart;
    public bool GameStopped
    {
        get { return gameStopped; } 

        set { gameStopped = value; }
    }


    //AllPlayingComponents.gameObject.SetActive(false);
    public void NewGame()
    {
        
        gameStopped = false;
        floors.FirstFloor();
        transitionPanel.FadeOut();
        healthText.SetActive(true);
        
        //AllPlayingComponents.gameObject.SetActive(true);
        //reset all playing components;

    }

    public void WinGame()
    {
        transitionPanel.FadeIn();
        gameStopped = true;
        healthText.SetActive(false);
        restart.WaitForRestart();
        //text WaitForSeconds(transitionPanel.FadeDuration) you won

    }

    public void LooseGameDeath()
    {

        transitionPanel.FadeIn();
        gameStopped = true;
        healthText.SetActive(false);
        restart.WaitForRestart();

        //text WaitForSeconds(transitionPanel.FadeDuration) you died
    }

    public void LooseGameDebt()
    {
        transitionPanel.FadeIn();
        gameStopped = true;
        healthText.SetActive(false);
        restart.WaitForRestart();
        //text WaitForSeconds(transitionPanel.FadeDuration) you will end your life in slavery   
    }

    
    
}
