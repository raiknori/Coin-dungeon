using DG.Tweening;
using UnityEngine;

public class CoinAnimation:MonoBehaviour
{
    [SerializeField][Range(0.3f,3f)] float flipDuration;
    [SerializeField][Range(0.3f, 3f)] float moveDuration;
    [SerializeField] GameObject coin1; [SerializeField] GameObject coin2;

    [SerializeField] Transform coinShowTransform;
    [SerializeField] Transform coinHideTransofrm;

    DG.Tweening.Sequence sequenceFlip1;
    DG.Tweening.Sequence sequenceFlip2;


    public void DoShowAnim()
    {
        coin1.transform.DOMoveX(coinShowTransform.position.x, moveDuration);
        coin2.transform.DOMoveX(coinShowTransform.position.x, moveDuration);
    }



    public void DoFlipAnim()
    {
        sequenceFlip1 = DOTween.Sequence();
        sequenceFlip1.Append(coin1.transform.DOScaleX(-1, flipDuration / 2)).Append(sequenceFlip1.PrependInterval(0.3f)).Append(coin1.transform.transform.DOScaleX(1, flipDuration / 2));

        sequenceFlip2 = DOTween.Sequence();
        sequenceFlip2.Append(coin2.transform.DOScaleX(-1, flipDuration / 2)).Append(sequenceFlip2.PrependInterval(0.3f)).Append(coin2.transform.transform.DOScaleX(1, flipDuration / 2));
        sequenceFlip1.Join(sequenceFlip2);

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