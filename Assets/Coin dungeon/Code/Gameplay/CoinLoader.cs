using UnityEngine;
using UnityEngine.UIElements;

public class CoinLoader:Component
{
    [SerializeField] Coin coin1;
    [SerializeField] Coin coin2;
    [SerializeField] CoinData[] coinsData;
    [SerializeField] CoinAnimation coinAnimation;

    void GetCoins()
    {
        int randomIndex1;
        int randomIndex2;

        do
        {
            randomIndex1 = UnityEngine.Random.Range(0, coinsData.Length );
            randomIndex2 = UnityEngine.Random.Range(0, coinsData.Length );
        }
        while (randomIndex1 != randomIndex2);

        coin1.LoadData( coinsData[randomIndex1]);
        coin2.LoadData( coinsData[randomIndex2]);



    }

    void Ineractable(bool ineractable)
    {
        coin1.Ineractable = ineractable;
        coin2.Ineractable =ineractable;
    }

    public void ShowCoins()
    {
        GetCoins();

        coinAnimation.DoShowAnim();
    }

    public void HideCoins()
    {

        coinAnimation.DoHideAnim();
    }

}
