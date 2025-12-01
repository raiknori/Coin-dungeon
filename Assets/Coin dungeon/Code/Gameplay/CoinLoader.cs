using UnityEngine;

public class CoinLoader:Component
{
    [SerializeField] Coin coin1;
    [SerializeField] Coin coin2;
    [SerializeField] CoinData[] coinsData;

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

    public void ShowCoins()
    {
        GetCoins();

        //show coins + anim
    }

    public void HideCoins()
    {
        //hide coins + anim
    }

}