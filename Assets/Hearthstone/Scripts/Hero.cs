using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public int maxHealth;                                                            
    public int armor;

    public Text healthText;

    int health;

    private void Start()
    {
        health = maxHealth;
        UpdateTextValues();
    }

    public void GainHealth(int healthGained)
    {
        if (health + healthGained <= maxHealth)
            health += healthGained;
        else
            health = maxHealth;

        UpdateTextValues();
    }

    public void LoseHealth(int healthLost)
    {
        health -= healthLost;
        UpdateTextValues();

        if (health <= 0)
            Died();
    }

    public void GainArmor(int armorGained)
    {

    }

    public void LoseArmor(int armorLost)
    {

    }

    private void UpdateTextValues()
    {
        healthText.text = health.ToString();
    }

    void Died()
    {

    }
}
