using System.Collections;
using UnityEngine;

enum DirectionMove
{
    up, down, left, right
}

public class TurnCore:MonoBehaviour
{
    [SerializeField] Grid grid;
    [SerializeField] MovementCore movementCore;
    [SerializeField] GameCore game;

    bool coolDown = false;

    void Update()
    {
        if(!movementCore.IsMoving && !coolDown && !game.GameStopped)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                StartTurn(DirectionMove.up);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                StartTurn(DirectionMove.down);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartTurn(DirectionMove.left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartTurn(DirectionMove.right);
            }
        }
    }


    void StartTurn(DirectionMove directionMove)
    {
        StartCoroutine(DoTurn(directionMove));
    }

    [SerializeField][Range(0, 1f)] float cooldDown;
    IEnumerator DoTurn(DirectionMove directionMove)
    {
        if (directionMove == DirectionMove.up)
        {
            grid.PlayerPos = new Vector2Int(grid.PlayerPos.x, grid.PlayerPos.y+1);
        }
        else if(directionMove == DirectionMove.down)
        {
            grid.PlayerPos = new Vector2Int(grid.PlayerPos.x, grid.PlayerPos.y-1);
        }
        else if( directionMove == DirectionMove.left)
        {
            grid.PlayerPos = new Vector2Int(grid.PlayerPos.x-1, grid.PlayerPos.y);
        }
        else if(directionMove == DirectionMove.right)
        {
            grid.PlayerPos = new Vector2Int(grid.PlayerPos.x+1, grid.PlayerPos.y);
        }

        coolDown = true;
        yield return new WaitForSeconds(0.5f);
        coolDown= false;
    }


}