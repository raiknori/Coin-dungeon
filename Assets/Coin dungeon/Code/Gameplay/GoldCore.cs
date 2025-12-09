using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GoldCore:MonoBehaviour
{
    float gold = 0f;

    [SerializeField] [Range(0.1f,10f)] float goldX;
    [SerializeField] [Range(20,32)] float debt;
    [SerializeField] GameCore game;

    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI goldXText;
    public float Gold
    {
        get{return gold;}

        set
        {
            gold = value*goldX;
            
            goldText.text = $"gold:{gold.ToString("0.###")}";
            Debug.Log(gold);
            goldText.rectTransform.DOShakePosition(0.3f, 1, 20);
            //playsound gold;
        }
    }

    public float GoldX
    {
        get { return goldX; }

        set
        {
            goldX = value;
            goldXText.text = $"x{goldX.ToString("0.####")}";
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

    public void ClearGold()
    {
        gold = 0;
        goldText.text = "gold:0";
        goldX = 1;
        goldXText.text = "x1";
        debt = 20;
    }



}