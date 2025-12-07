using System.Collections;
using UnityEngine;

public class FloorCore:MonoBehaviour
{
    [SerializeField] Grid grid;
    [SerializeField] HealthCore health;
    [SerializeField][Range(3,10)] int finalFloor;
    [SerializeField] GoldCore gold;
    [SerializeField] GameCore game;
    private int floorCount = 0;


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

            if(floorCount%2==0)
            {
                //choice between recover and risk
                
            }

            NextFloor();
        }
    }
    public void FirstFloor()
    {

        health.MakeMaxHealth();
        grid.GridLoad();
        gameObject.GetComponent<TurnCore>().enabled = true;
        
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

    IEnumerator DoNextFloor()
    {
        game.GameStopped = true;

        transitionPanel.FadeIn();
        yield return new WaitForSeconds(transitionPanel.FadeDuration);
        grid.NewGrid();
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