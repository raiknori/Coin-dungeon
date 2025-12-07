using TMPro;
using UnityEngine;

public class HealthCore:MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] GameCore game;
    [SerializeField] TextMeshProUGUI healthText;
    public float Health
    {
        get { return health; }

        set
        {
            health = value;

            healthText.text = ($"health:{health}");

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
