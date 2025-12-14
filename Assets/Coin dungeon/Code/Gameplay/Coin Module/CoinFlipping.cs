using System.Collections;
using TMPro;
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

    [SerializeField] UIPanel headOrTailText;
    [SerializeField] GameObject headOrTailGo;

    [SerializeField] UIPanel earnedGoldText;
    [SerializeField] GameObject earnedGoldGo;

    [SerializeField] AudioManager audioManager;
    public IEnumerator Flip(Vector2Int target)
    {
        yield return new WaitForSeconds(audioManager.SoundDuration("coinChoose")*0.3f);
        audioManager.PlaySound("coinDrop");
        headOrTailGo.SetActive(true);
        headOrTailGo.transform.position = selectedCoin.transform.position;
        headOrTailText.GetComponent<CanvasGroup>().alpha = 1;
        headOrTailText.FadeOut();

        coinAnimation.DoFlipAnim();
        if (selectedCoin.DoRoll())
        {
            selectedCoin.spriteRenderer.sprite = selectedCoin.coinSpriteHead;
            Win(target);
        }
        else
        { 
            selectedCoin.spriteRenderer.sprite = selectedCoin.coinSpriteTail;
            Loose();
        }

        yield return new WaitForSeconds(coinAnimation.FlipDuration);
        headOrTailGo.SetActive(false);
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
        audioManager.PlaySound("coinChoose");
        coinSelected = true;
        selectedCoin = coin;
    }

    void Win(Vector2Int target)
    {
        var text = headOrTailText.GetComponent<TextMeshProUGUI>();
        text.text = "head!";

        text = earnedGoldText.GetComponent<TextMeshProUGUI>();
        var canvasGroup = text.GetComponent<CanvasGroup>();
        earnedGoldGo.transform.localPosition = grid.Position(target);

        canvasGroup.alpha = 1;
        float gold = 1*selectedCoin.GoldX;

        text.text = $"1*{selectedCoin.GoldX}={gold.ToString("0.####")}";
        earnedGoldText.FadeOut();

        grid.RemoveSpawnPoint(target);
        goldCore.Gold += 1*selectedCoin.GoldX*goldCore.GoldX;
    }

    void Loose()
    {
        var text = headOrTailText.GetComponent<TextMeshProUGUI>();
        text.text = "tail!";
        health.Health--;
    }
}
