using System.Collections;
using UnityEngine;

public class CoinFlipping
{

    [SerializeField] AttackCore attackCore;
    [SerializeField] Grid grid;
    [SerializeField] GoldCore goldCore;
    [SerializeField] HealthCore health;
    [SerializeField] GameObject selectCoinText;

    Coin selectedCoin;
    bool coinSelected = false;
    [SerializeField] CoinAnimation coinAnimation;
    public void Flip(Vector2Int target)
    {

        coinAnimation.DoFlipAnim();
        if (selectedCoin.DoRoll())
        {
            Win(target);
        }
        else
        {
            Loose();
        }
    }
    public IEnumerator SelectingCoin()
    {
        coinSelected = false;

        selectCoinText?.SetActive(true);
        while (!coinSelected)
        {

            yield return null;
        }

        selectCoinText?.SetActive(false);

    }

    public void SelectCoin(Coin coin) //Listener to coin button ui
    {
        coinSelected = true;
        selectedCoin = coin;
    }

    void Win(Vector2Int target)
    {
        grid.RemoveSpawnPoint(target);
        goldCore.Gold += 1*selectedCoin.GoldX;
    }

    void Loose()
    {
        health.Health--;
    }
}
