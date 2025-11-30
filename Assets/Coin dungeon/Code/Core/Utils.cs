using System;
using System.Linq;
using UnityEngine;
public class Utils
{
    public static Vector2 RandomVector2(float minInclusiveXY, float maxInclusiveXY)
    {
        Vector2 vector = new Vector2();

        vector.x = UnityEngine.Random.Range(minInclusiveXY, maxInclusiveXY);
        vector.y = UnityEngine.Random.Range(minInclusiveXY, maxInclusiveXY);

        return vector;
    }

    public static Vector2 RandomVector2(float minInclusiveX, float maxInclusiveX, float minInclusiveY, float maxInclusiveY)
    {
        Vector2 vector = new Vector2();

        vector.x = UnityEngine.Random.Range(minInclusiveX, maxInclusiveX);
        vector.y = UnityEngine.Random.Range(minInclusiveY, maxInclusiveY);

        return vector;
    }

    public static Vector2Int RandomVector2(int minInclusiveX, int maxInclusiveX, int minInclusiveY, int maxInclusiveY)
    {
        Vector2Int vector = new Vector2Int();

        vector.x = UnityEngine.Random.Range(minInclusiveX, maxInclusiveX);
        vector.y = UnityEngine.Random.Range(minInclusiveY, maxInclusiveY);
        
        return vector;
    }

    public static Vector2 RandomVector2(Vector2 value)
    {
        Vector2 vector = new Vector2();

        vector.x = UnityEngine.Random.Range(value.x, value.y);
        vector.y = UnityEngine.Random.Range(value.x, value.y);

        return vector;
    }
}

