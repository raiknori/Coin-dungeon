using System;
using System.Linq;
using UnityEngine;

public class Grid:Component
{
    ImpactCore impactCore;


    Vector2[,] grid = new Vector2[4, 8];

    Vector2Int playerPos = new Vector2Int();

    public Vector2Int PlayerPos
    {
        get 
        {
            return playerPos;
        }
        set
        {
            if ((value.x > 7 || value.x < 0) || (value.y > 3 || value.y < 0))
            {
                impactCore.Deny();
                return;
            }
            
            playerPos = value;

            
        }
    }
    
    public Vector2 Position(Vector2Int pos)
    {
        if (pos.x >= grid.GetLength(0) || pos.y >= grid.GetLength(1))
            Debug.LogError("Grid.Position(Vector2Int pos) index out of array");

        return grid[pos.x, pos.y];
    }

    public void GridLoad()
    {
        MakeGrid();
        SpawnPlayer();
        Spawn();
    }

    void MakeGrid()
    {
        for (int i = 0; i < 4; i++)
        {

            for (int j = 0; j < 8; j++)
            {
                grid[i, j] = new Vector2(-i * 50, j * 50);
            }
        }

    }

    void SpawnPlayer()
    {
        playerPos = Utils.RandomVector2(0, 7, 0, 3);
    }


    [SerializeField][Range(1, 5)] int enemyMaxAmount;
    void Spawn()
    {
        int enemyAmount = UnityEngine.Random.Range(1, enemyMaxAmount);

        Vector2Int[] spawnPoints = new Vector2Int[enemyAmount];

        for (int i = 0; i < enemyAmount; i++)
        {
            Vector2Int spawnPoint;

            do
            {
                spawnPoint = Utils.RandomVector2(0, 7, 0, 3);

                spawnPoints[i] = spawnPoint;

                

            } while(!(spawnPoints.Contains(spawnPoint)) || CheckBorderingPosition(playerPos,spawnPoint));
        }
    }

    public bool CheckBorderingPosition(Vector2Int center, Vector2 target)
    {
        if (center.x + 1 == target.x || center.x - 1 == target.x)
        {
            return true;
        }
        else if (center.y + 1 == target.y || center.y - 1 == target.y)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}

