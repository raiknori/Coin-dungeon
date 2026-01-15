using System.Collections;
using UnityEngine;
using Zenject;

public class AttackCore:MonoBehaviour
{
    [Inject] CoinFlipping coinFlipping;

    public IEnumerator Attack(Vector2Int target)
    {
        yield return StartCoroutine( coinFlipping.Flip(target));
        yield break;
    }

    public IEnumerator SelectCoin()
    {
        yield return StartCoroutine(coinFlipping.SelectingCoin());

    }
}
