

using UnityEngine;

public class Coin:Component
{
    [Range(0, 1f)][SerializeField] float winChance;

    [Range(0,1f)][SerializeField] float goldX;

    public void DoRoll()
    {
        var randomVal = Random.Range(0f, 1f);

        if (winChance >= randomVal)
            Win();
        else
            Loose();
    }

    void Win()
    {

    }
    void Loose()
    {

    }
}