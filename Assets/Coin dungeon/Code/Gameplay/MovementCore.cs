using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
using static UnityEngine.GraphicsBuffer;

public class MovementCore:MonoBehaviour
{
    [Inject] Grid grid;

    public GameObject player;
    [Inject] AttackCore attackCore;
    [Inject] AudioManager audioManager;

    Coroutine moveCoroutine;
    public void DeffaultMove()
    {
        StartCoroutine(DoMove());
    }

    public void AttackMove(Vector2Int target)
    {

        StartCoroutine(DoAttackMove(target));


    }

    public void DenyMove()
    {
        ImpactCore.Shake();
        audioManager.PlaySound("deny");
    }

    [SerializeField][Range(0,5f)] float moveDuration;

    bool isMoving = false;

    public bool IsMoving
    {
        get { return isMoving; }
        private set { }
    }

    IEnumerator DoMove()
    {
        isMoving = true;

        var startPosition = player.transform.localPosition;

        float elapsed = 0;

        audioManager.PlaySound("step");

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;

            player.transform.localPosition = Vector3.Lerp(startPosition, grid.Position(grid.PlayerPos), elapsed/moveDuration);

            yield return null;

        }


        isMoving = false;
    }

    IEnumerator DoAttackMove(Vector2Int target)
    {
        isMoving = true;

        yield return StartCoroutine(attackCore.SelectCoin());

        var startPosition = player.transform.localPosition;

        float elapsed = 0;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;

            player.transform.localPosition = Vector3.Lerp(startPosition, grid.Position(target), elapsed / moveDuration);

            yield return null;

        }

        yield return StartCoroutine(attackCore.Attack(target));
        //deny play


        elapsed = 0;

        while (elapsed < moveDuration / 2)
        {
            elapsed += Time.deltaTime;

            player.transform.localPosition = Vector3.Lerp(grid.Position(target), startPosition, elapsed / (moveDuration/2));

            yield return null;
        }


        isMoving = false;
    }



 


}