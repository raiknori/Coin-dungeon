using TMPro;
using UnityEngine;

public class HealthCore:MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] GameCore game;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField][Range(1, 10)] int maxHealth;
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
        Health = (float)maxHealth;
    }
    public void Death()
    {
        game.LooseGameDeath();
    }
    
}
