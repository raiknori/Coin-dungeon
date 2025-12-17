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
    [SerializeField] GameObject tutorialText; 

    bool coolDown = false;
    public static bool Tutorial = true;

    private void Start()
    {
        StartCoroutine(MoveTutorial());
    }

    IEnumerator MoveTutorial()
    {
        tutorialText?.SetActive(true);

        while(TurnCore.Tutorial)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");


            if ( h != 0 || v != 0)
            {
                break;
            }

            yield return null;
        }

        tutorialText?.gameObject.SetActive(false);
        TurnCore.Tutorial = false;
    }
    void Update()
    {
        if(!movementCore.IsMoving && !coolDown && !game.GameStopped)
        {
            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                StartTurn(DirectionMove.up);
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                StartTurn(DirectionMove.down);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                StartTurn(DirectionMove.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
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
            grid.PlayerPos = new Vector2Int(grid.PlayerPos.x, grid.PlayerPos.y-1);
        }
        else if(directionMove == DirectionMove.down)
        {
            grid.PlayerPos = new Vector2Int(grid.PlayerPos.x, grid.PlayerPos.y+1);
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