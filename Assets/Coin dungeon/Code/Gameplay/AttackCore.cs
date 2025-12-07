using System.Collections;
using UnityEngine;

public class AttackCore:MonoBehaviour
{
    [SerializeField] CoinFlipping coinFlipping;

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
