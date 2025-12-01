using UnityEngine;
using UnityEngine.UIElements;

public class GameCore:Component
{
    bool gameStopped = true;
    [SerializeField] Grid grid;

    public bool GameStopped
    {
        get { return gameStopped; } 

        set { gameStopped = value; }
    }

    public void NewGame()
    {
        grid.GridLoad();
        gameStopped = false;

        
    }

    public void WinGame()
    {
        gameStopped = true;

        
    }

    public void LooseGameDeath()
    {
        gameStopped = true;

    }

    public void LooseGameDebt()
    {
        gameStopped = true;
    }
}

