using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class MovementCore:MonoBehaviour
{
    [SerializeField] Grid grid;

    [SerializeField] GameObject player;
    [SerializeField] ImpactCore impactCore;
    [SerializeField] AttackCore attackCore;

    Coroutine moveCoroutine;
    public void DeffaultMove()
    {
        StartCoroutine(DoMove());
    }

    public void AttackMove(Vector2Int target)
    {

        StartCoroutine(DoAttackMove(target));


    }

    public void DenyMove(Vector2Int target)
    {


        StartCoroutine(DoDenyMove(target));
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

        var startPosition = player.transform.position;

        float elapsed = 0;

        while(elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;

            player.transform.position = Vector3.Lerp(startPosition, grid.Position(grid.PlayerPos), elapsed/moveDuration);

            yield return null;

        }


        isMoving = false;
    }

    IEnumerator DoAttackMove(Vector2Int target)
    {
        isMoving = true;

        yield return StartCoroutine(attackCore.SelectCoin());

        var startPosition = player.transform.position;

        float elapsed = 0;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;

            player.transform.position = Vector3.Lerp(startPosition, grid.Position(target), elapsed / moveDuration);

            yield return null;

        }

        yield return StartCoroutine(attackCore.Attack(target));
        impactCore.Shake();


        elapsed = 0;

        while (elapsed < moveDuration / 2)
        {
            elapsed += Time.deltaTime;

            player.transform.position = Vector3.Lerp(grid.Position(target), startPosition, elapsed / moveDuration);

            yield return null;
        }


        isMoving = false;
    }



    IEnumerator DoDenyMove(Vector2Int target)
    {
        isMoving = true;

        var startPosition = player.transform.position;

        float elapsed = 0;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;

            player.transform.position = Vector3.Lerp(startPosition, grid.Position(target), elapsed / moveDuration);

            yield return null;

        }


            impactCore.Shake();


        elapsed = 0;

        while (elapsed < moveDuration / 2)
        {
            elapsed += Time.deltaTime;

            player.transform.position = Vector3.Lerp(grid.Position(target), startPosition, elapsed / moveDuration);

            yield return null;
        }


        isMoving = false;
    }

 


}