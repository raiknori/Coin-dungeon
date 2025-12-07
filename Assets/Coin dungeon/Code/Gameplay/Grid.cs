
using NUnit.Framework.Internal.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEngine.GraphicsBuffer;

public class Grid : MonoBehaviour
{

    Vector2[,] grid = new Vector2[8, 4];

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
                movementCore.DenyMove();
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

    GameObject PlayerGObj;

    public Vector2 Position(Vector2Int pos)
    {
        if (pos.x >= grid.GetLength(0) || pos.y >= grid.GetLength(1))
            Debug.LogError("Grid.Position(Vector2Int pos) index out of array");

        return grid[pos.x, pos.y];
    }

    public void GridLoad()
    {
        ClearGrid();
        MakeGrid();
        NewGrid();
    }

    public void NewGrid()
    {
        ClearGrid();
        SpawnPlayer();
        Spawn();
    }

    void MakeGrid()
    {
        for (int i = 0; i < 8; i++)
        {

            for (int j = 0; j < 4; j++)
            {
                grid[i, j] = new Vector2(i * 50, -j * 50);
            }
        }

    }

    void ClearGrid()
    {
        if(PlayerGObj!=null)
        {
            Destroy(PlayerGObj);
            
        }

        if(spawnPointsGO.Count>0)
        {
            foreach(var go in spawnPointsGO)
            {
                Destroy(go);
            }

            spawnPointsGO.Clear();
        }

        if(spawnPoints.Count>0)
        {
            spawnPoints.Clear();
        }

    }

    [SerializeField] GameObject playerPrefab;
    void SpawnPlayer()
    {
        playerPos = Utils.RandomVector2(0, 7, 0, 3);

        PlayerGObj = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
        PlayerGObj.transform.localPosition = Position(playerPos);

        movementCore.player = PlayerGObj;
        Debug.Log($"Player pos: {playerPos}; {Position(playerPos)}");
    }


    [SerializeField][Range(1, 5)] int enemyMaxAmount;
    List<Vector2Int> spawnPoints = new List<Vector2Int>();
    List<GameObject> spawnPointsGO = new List<GameObject>();
    [SerializeField] FloorCore floorCore;

    public void RemoveSpawnPoint(Vector2Int target)
    {
        if (spawnPoints.Contains(target))
        {
            Disappear(spawnPointsGO[spawnPoints.IndexOf(target)]);

            spawnPointsGO.RemoveAt(spawnPoints.IndexOf(target));

            spawnPoints.Remove(target);

            if (spawnPoints.Count <= 0)
            {
                floorCore.FloorCount++;
            }

        }


    }


    void Spawn()
    {
        int enemyAmount = UnityEngine.Random.Range(1, enemyMaxAmount+1);


        for (int i = 0; i < enemyAmount+1; i++)
        {
            Vector2Int spawnPoint;

            do
            {
                spawnPoint = Utils.RandomVector2(0, 7, 0, 3);

            } while ((spawnPoints.Contains(spawnPoint)) || CheckBorderingPosition(playerPos, spawnPoint) || spawnPoint==playerPos);

            spawnPoints.Add(spawnPoint);

        }

        foreach (var sp in spawnPoints)
        {
            Debug.Log($"Enemy will be spawned at: {sp.x}; {sp.y}; (Position: ${Position(sp)})");

            var gameObj = (Instantiate(GetEnemy(), new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform));
            gameObj.transform.localPosition = Position(sp);

            spawnPointsGO.Add(gameObj);
        }
    }

    [SerializeField] GameObject[] enemiesPrefabs;
    GameObject GetEnemy()
    {
        return enemiesPrefabs[UnityEngine.Random.Range(0,enemiesPrefabs.Length)];
    }

    void Disappear(GameObject gbject)
    {
        var sr = gbject.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            StartCoroutine(DoDisappear(sr));
        }
    }

    [SerializeField][Range(0, 1f)] float disappearTime;
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

