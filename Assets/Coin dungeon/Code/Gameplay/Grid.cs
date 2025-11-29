using System;
using UnityEngine;

public class Grid
{
    static Vector2[,] grid = new Vector2[4, 8];

    static void MakeGrid()
    {
        for (int i = 0; i < 4; i++)
        {

            for (int j = 0; j < 8; j++)
            {

                grid[i, j] = new Vector2(-i * 50, j * 50);
            }
        }

    }

}
