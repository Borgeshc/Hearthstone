using UnityEngine;
using UnityEngine.UI;

public class MonsterCard : MonoBehaviour
{
    public int baseMana;
    public int baseAttack;
    public int baseHealth;

    public Text manaTextInHand;
    public Text attackTextInHand;
    public Text healthTextInHand;

    public Text manaTextInPlay;
    public Text attackTextInPlay;
    public Text healthTextInPlay;

    int mana;
    int attack;
    int originalBaseHealth;
    int health;

    MonsterCard target;

    public void Start()
    {
        SetVariables();
        UpdateValues();
    }

    void SetVariables()
    {
        originalBaseHealth = baseHealth;
        health = baseHealth;
        attack = baseAttack;
        mana = baseMana;
    }


#region Health
    public void LoseHealth(int healthLost)
    {
        health -= healthLost;
        UpdateValues();

        if (health <= 0)
            CardDestroyed();
    }

    public void GainHealth(int healthGained)
    {
        if (health + healthGained <= baseHealth)
            health += healthGained;
        else
            health = baseHealth;

        UpdateValues();
    }

    public void SetHealth(int setHealthTo)
    {
        baseHealth = setHealthTo;
        health = baseHealth;
        UpdateValues();
    }

    public void GainMaxHealth(int maxHealthGained)
    {
        baseHealth += maxHealthGained;
        health += maxHealthGained;
        UpdateValues();
    }
    #endregion

#region Mana

    public void IncreaseManaCost(int manaIncrease)
    {
        mana += manaIncrease;
        UpdateValues();
    }

    public void ReduceManaCost(int manaReduction)
    {
        if (mana - manaReduction >= 0)
            mana -= manaReduction;
        else
            mana = 0;

        UpdateValues();
    }

    public void SetManaCost(int setManaTo)
    {
        if (setManaTo >= 0)
            mana = setManaTo;
        else
            mana = 0;

        UpdateValues();
    }
    #endregion

#region Attack

    public void IncreaseAttack(int attackIncrease)
    {
        attack += attackIncrease;
        UpdateValues();
    }

    public void DecreaseAttack(int attackDecrease)
    {
        if (attack - attackDecrease >= 0)
            attack -= attackDecrease;
        else
            attack = 0;

        UpdateValues();
    }

    public void SetAttack(int setAttackTo)
    {
        if (setAttackTo >= 0)
            attack = setAttackTo;
        else
            attack = 0;

        UpdateValues();
    }

#endregion

    public void Attack()
    {
        target.LoseHealth(attack);
        LoseHealth(target.attack);
    }

    void CardDestroyed()
    {
        //Destroy(gameObject);
    }

    void UpdateValues()
    {
        UpdateValueColors();
        healthTextInHand.text = health.ToString();
        attackTextInHand.text = attack.ToString();
        manaTextInHand.text = mana.ToString();

        healthTextInPlay.text = health.ToString();
        attackTextInPlay.text = attack.ToString();
        manaTextInPlay.text = mana.ToString();
    }

    void UpdateValueColors()
    {
        if (health >= baseHealth && health != originalBaseHealth)
            healthTextInPlay.color = Color.green;
        else if (health < baseHealth)
            healthTextInPlay.color = Color.red;
        else if (health == baseHealth)
            healthTextInPlay.color = Color.white;

        if (attack > baseAttack)
            attackTextInPlay.color = Color.green;
        else if (attack < baseAttack)
            attackTextInPlay.color = Color.red;
        else if (attack == baseAttack)
            attackTextInPlay.color = Color.white;
    }
}
