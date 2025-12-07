

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Coin : MonoBehaviour, IPointerClickHandler
{
    float winChance;

    float goldX;

    



    public Sprite coinSpriteHead;
    public Sprite coinSpriteTail;
    public Sprite coinSpriteDeffault;
    [SerializeField] CoinFlipping coinFlipping;
    string description;
    string name;
    bool ineractable =true;


    [SerializeField] TooltipPanel tooltipPanel;
    [SerializeField] Collider2D collider;
    public SpriteRenderer spriteRenderer;
    public float GoldX
    {
        get { return goldX; }

        private set { goldX = value; }
    }

    public bool Ineractable
    {
        get { return ineractable; }
        set 
        {  
            ineractable = value;

            if(ineractable)
            {
                collider.enabled = true;
            }
            else
            {
                collider.enabled = false;
            }
        }
    }

    public void LoadData(CoinData data)
    {
        winChance = data.winChance;
        goldX = data.goldX;
        coinSpriteHead = data.coinSpriteHead;
        coinSpriteTail = data.coinSpriteTail;
        coinSpriteDeffault = data.coinSpriteDeffault;

        spriteRenderer.sprite = coinSpriteDeffault;

        name = data.name;
        description = data.description;

        tooltipPanel.tooltipTitle = name;
        tooltipPanel.tooltipDescription = description;


    }
    public bool DoRoll()
    {
        var randomVal = Random.Range(0f, 1f);

        if (winChance >= randomVal)
            return true;
        else
            return false;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        coinFlipping.SelectCoin(this);
        Debug.Log($"Coin clicked! {description}");
    }


}

