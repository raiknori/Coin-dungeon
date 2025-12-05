using UnityEngine;

public class HealthCore:Component
{
    [SerializeField] float health;
    [SerializeField] GameCore game;

    public float Health
    {
        get { return health; }

        set 
        {
            health = value;

            if(health <= 0)
            {
                Death();
            }
        }
    }

    public void MakeMaxHealth()
    {
        Health = 3;
    }
    public void Death()
    {
        game.LooseGameDeath();
    }
    
}
