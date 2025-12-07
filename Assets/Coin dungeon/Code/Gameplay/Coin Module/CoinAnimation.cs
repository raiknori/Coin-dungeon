using DG.Tweening;
using System.Collections;
using UnityEngine;

public class CoinAnimation:MonoBehaviour
{
    [SerializeField][Range(0.3f,3f)] float flipDuration;
    [SerializeField][Range(0.3f, 3f)] float moveDuration;
    [SerializeField] GameObject coin1; [SerializeField] GameObject coin2;
    [SerializeField] Coin coin1Coin; [SerializeField] Coin coin2Coin;

    [SerializeField] Transform coinShowTransform;
    [SerializeField] Transform coinHideTransofrm;

    DG.Tweening.Sequence sequenceFlip1;
    DG.Tweening.Sequence sequenceFlip2;

    public float MoveDuration
    {
        get { return moveDuration; }

        private set { moveDuration = value; }   
    }

    public float FlipDuration
    {
        get { return flipDuration; }

        set { flipDuration = value; }
    }
    
    public void DoShowAnim()
    {
        coin1.transform.DOMoveX(coinShowTransform.position.x, moveDuration);
        coin2.transform.DOMoveX(coinShowTransform.position.x, moveDuration);
    }



    public void DoFlipAnim()
    {
        coin1Coin.spriteRenderer.sprite = coin1Coin.coinSpriteDeffault;
        coin2Coin.spriteRenderer.sprite = coin2Coin.coinSpriteDeffault;

        coin1.transform.DOShakePosition(flipDuration);
        coin2.transform.DOShakePosition(flipDuration);

    }

    public void DoHideAnim()
    {
        coin1.transform.DOMoveX(coinHideTransofrm.position.x, moveDuration);
        coin2.transform.DOMoveX(coinHideTransofrm.position.x, moveDuration);

        Vector3 posCoin1 = coin1.transform.position;
        Vector3 posCoin2 = coin2.transform.position;

        posCoin1.x = coinHideTransofrm.position.x;
        posCoin2.x = coinHideTransofrm.position.x;


        coin1.transform.position = posCoin1;
        coin2.transform.position = posCoin2;
    }
}