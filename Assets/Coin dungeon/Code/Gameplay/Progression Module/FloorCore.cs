using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

public class FloorCore:MonoBehaviour
{
    [Inject] Grid grid;
    [Inject] HealthCore health;
    [SerializeField][Range(3,10)] int finalFloor;
    [Inject] GoldCore gold;
    [Inject] GameCore game;
    private int floorCount = 1;


    [SerializeField][Range(1, 10)] int choiceEveryFloor;
    [Inject] ButtonLoader buttonLoader;
    public int FloorCount
    {
        get
        {
            return floorCount;
        }
        set
        {
            floorCount = value;

            if(floorCount>= finalFloor)
            {
                FinalFloor();
                return;
            }

            if(floorCount%choiceEveryFloor==0)
            {
                //choice between recover and risk
                buttonLoader.ShowButtons();
                return;
            }

            NextFloor();
        }
    }

    public void ClearFloor()
    {
        floorCount = 1;
    }

    [SerializeField] GameObject turnCore;
    public void FirstFloor()
    {
        gold.ClearGold();
        health.MakeMaxHealth();
        grid.GridLoad();

        turnCore.GetComponent<TurnCore>().enabled = true;
    }

    public void NextFloor()
    {
       StartCoroutine(DoNextFloor());
    }

    public void NextFloorRisk()
    {
        gold.GoldX += 0.8f;
        NextFloor();
    }
    public void Recover()
    {
        health.MakeMaxHealth();
        gold.Debt += gold.Debt * 0.3f;
        NextFloor();
    }


    [SerializeField] UIPanel transitionPanel;
    [SerializeField] UIPanel debtText;
    IEnumerator DoNextFloor()
    {
        game.GameStopped = true;

        transitionPanel.FadeIn();
        yield return new WaitForSeconds(transitionPanel.FadeDuration);
        grid.NewGrid();
        debtText.GetComponent<TextMeshProUGUI>().text = $"debt:{gold.Debt}\nfloor:{floorCount}/{finalFloor}";
        debtText.FadeIn();
        yield return new WaitForSeconds(debtText.FadeDuration*2);
        debtText.FadeOut();
        transitionPanel.FadeOut();
        yield return new WaitForSeconds(transitionPanel.FadeDuration);

        game.GameStopped = false;
    }




    public void FinalFloor()
    {
        StartCoroutine(DoFinalFloor());
    }
    IEnumerator DoFinalFloor()
    {
        game.GameStopped = true;

        transitionPanel.FadeIn();
        yield return new WaitForSeconds(transitionPanel.FadeDuration);
        gold.PayDebt();
    }




}