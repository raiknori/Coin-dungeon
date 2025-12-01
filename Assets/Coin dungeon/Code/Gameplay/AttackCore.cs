using System.Collections;
using UnityEngine;

public class AttackCore:MonoBehaviour
{
    [SerializeField] CoinFlipping coinFlipping;

    public IEnumerator Attack(Vector2Int target)
    {
        coinFlipping.Flip(target);
        yield break;
    }

    public IEnumerator SelectCoin()
    {
        yield return StartCoroutine(coinFlipping.SelectingCoin());

    }
}
