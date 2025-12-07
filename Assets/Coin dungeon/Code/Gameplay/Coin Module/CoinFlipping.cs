using System.Collections;
using UnityEngine;

public class CoinFlipping:MonoBehaviour
{

    [SerializeField] AttackCore attackCore;
    [SerializeField] Grid grid;
    [SerializeField] GoldCore goldCore;
    [SerializeField] HealthCore health;
    [SerializeField] GameObject selectCoinText;

    Coin selectedCoin;
    bool coinSelected = false;
    [SerializeField] CoinAnimation coinAnimation;
    [SerializeField] CoinLoader coinLoader;
    public IEnumerator Flip(Vector2Int target)
    {

        coinAnimation.DoFlipAnim();
        if (selectedCoin.DoRoll())
        {
            Win(target);
            selectedCoin.spriteRenderer.sprite = selectedCoin.coinSpriteHead;
        }
        else
        {
            selectedCoin.spriteRenderer.sprite = selectedCoin.coinSpriteTail;
            Loose();
        }

        yield return new WaitForSeconds(coinAnimation.FlipDuration);

        coinLoader.HideCoins();
    }
    public IEnumerator SelectingCoin()
    {
        coinSelected = false;
        coinLoader.ShowCoins();
        yield return new WaitForSeconds(coinAnimation.MoveDuration);

        selectCoinText?.SetActive(true);
        while (!coinSelected)
        {

            yield return null;
        }

        Debug.Log("We jumped from while loop");

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
        //show text
    }

    void Loose()
    {
        health.Health--;
    }
}
