using System.Diagnostics;
using UnityEngine;

public class GoldCore:MonoBehaviour
{
    float gold = 0f;

    [SerializeField] [Range(0.1f,10f)] float goldX;
    [SerializeField] [Range(20,32)] float debt;
    [SerializeField] GameCore game;
    public float Gold
    {
        get{return gold;}

        set
        {
            gold = value*goldX;
        }
    }

    public float GoldX
    {
        get { return goldX; }

        set
        {
            goldX = value;
        }
    }

    public float Debt
    {
        get
        {

            return debt;
        }

        set
        {
            debt = value;
        }
    }
    public void PayDebt()
    {
        if(gold<debt)
        {
            game.LooseGameDebt();
        }
        else
        {
            game.WinGame();
        }
    }




}