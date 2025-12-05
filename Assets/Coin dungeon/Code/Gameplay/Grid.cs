
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Grid:MonoBehaviour
{

    Vector2[,] grid = new Vector2[4, 8];

    Vector2Int playerPos = new Vector2Int();

    [SerializeField] MovementCore movementCore;
    

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
                movementCore.DenyMove(value);
                return;
            }

            if (spawnPoints != null && spawnPoints.Contains(value))
            {
                movementCore.AttackMove(value);
                return;
            }

            
            
            playerPos = value;


            movementCore.DeffaultMove();
            
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
        NewGrid();
    }

    public void NewGrid()
    {
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
    List<Vector2Int> spawnPoints = new List<Vector2Int>();
    List<GameObject> spawnPointsGO = new List<GameObject>();
    [SerializeField] FloorCore floorCore;

    public void RemoveSpawnPoint(Vector2Int target)
    {
        if(spawnPoints.Contains(target))
        {
            Disappear(spawnPointsGO[spawnPoints.IndexOf(target)]);

            spawnPointsGO.RemoveAt(spawnPoints.IndexOf(target));

            spawnPoints.Remove(target);

            if(spawnPoints.Count <= 0)
            {
                floorCore.FloorCount++;
            }

        }
    }


    void Spawn()
    {
        int enemyAmount = UnityEngine.Random.Range(1, enemyMaxAmount);


        for (int i = 0; i < enemyAmount; i++)
        {
            Vector2Int spawnPoint;

            do
            {
                spawnPoint = Utils.RandomVector2(0, 7, 0, 3);

                spawnPoints.Add(spawnPoint);



            } while(!(spawnPoints.Contains(spawnPoint)) || CheckBorderingPosition(playerPos,spawnPoint));

            foreach(var sp in spawnPoints)
            {
                spawnPointsGO.Add(Instantiate(GetEnemy(),Position(sp),Quaternion.identity ,gameObject.transform));
            }
        }
    }

    [SerializeField] GameObject testEnemyPrefab;
    GameObject GetEnemy()
    {
        return testEnemyPrefab;
    }

    void Disappear(GameObject gbject)
    {
        var sr = gbject.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            StartCoroutine(DoDisappear(sr));
        }
    }

    [SerializeField][Range(0,1f)] float disappearTime;
    IEnumerator DoDisappear(SpriteRenderer spriteRenderer)
    {
        float elapsed = 0;

        Color startColor = spriteRenderer.color;
        Color endColor = spriteRenderer.color;
        endColor.a = 0;


        while (elapsed < disappearTime)
        {
            elapsed += Time.deltaTime;

            spriteRenderer.color = Color.Lerp(startColor, endColor, elapsed / disappearTime);

            yield return null;

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

