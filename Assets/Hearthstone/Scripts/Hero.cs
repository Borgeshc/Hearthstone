using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    [Header("Mana Crystals")]
    public GameObject[] manaCrystals;
    public Text currentManaText;
    public Text maxManaText;

    int currentMana;
    int maxMana;

    [Space, Header("Stats")]
    public int maxHealth;                                                            
    public int armor;

    [HideInInspector]
    public bool playerOne;
    [HideInInspector]
    public bool myTurn;

    public Text healthText;

    int health;

    private void Start()
    {
        health = maxHealth;
        SetReferences();
        UpdateHealthValues();
        UpdateManaCrystals();
    }

    private void SetReferences()
    {
        if(playerOne)
        {
            currentManaText = GameObject.Find("PlayerOneCurrentMana").GetComponent<Text>();
            maxManaText = GameObject.Find("PlayerOneMaxMana").GetComponent<Text>();

            foreach (GameObject go in manaCrystals)
            {
                go.SetActive(false);
            }

            manaCrystals[0].SetActive(true);
        }
        else
        {
            currentManaText = GameObject.Find("PlayerTwoCurrentMana").GetComponent<Text>();
            maxManaText = GameObject.Find("PlayerTwoMaxMana").GetComponent<Text>();
        }
    }

    #region Health
    public void GainHealth(int healthGained)
    {
        if (health + healthGained <= maxHealth)
            health += healthGained;
        else
            health = maxHealth;

        UpdateHealthValues();
    }

    public void LoseHealth(int healthLost)
    {
        health -= healthLost;
        UpdateHealthValues();

        if (health <= 0)
            Died();
    }

    private void UpdateHealthValues()
    {
        healthText.text = health.ToString();
    }
    #endregion
    #region Armor
    public void GainArmor(int armorGained)
    {

    }

    public void LoseArmor(int armorLost)
    {

    }
    #endregion
    #region Mana
    public void IncreaseMana(int increaseAmount)
    {
        for (int i = 0; i < increaseAmount; i++)
        {
            if (currentMana + 1 <= maxMana)
                currentMana ++;
            else
                currentMana = maxMana;

            UpdateManaCrystals();

            if (playerOne)
            {
                if (currentMana > 0)
                    manaCrystals[currentMana - 1].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .75f);
            }
        }
    }

    public void DecreaseMana(int decreaseAmount)
    {
        for (int i = 0; i < decreaseAmount; i++)
        {
            if (currentMana - 1 >= 0)
                currentMana--;
            else
                currentMana = 0;

            UpdateManaCrystals();

            if (playerOne)
            {
                if (currentMana > 0)
                    manaCrystals[currentMana].GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, .5f, .75f);
                else
                    manaCrystals[0].GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, .5f, .75f);
            }
        }
    }

    public void IncreaseMaxMana(int increaseAmount)
    {
        for (int i = 0; i < increaseAmount; i++)
        {
            if (maxMana + 1 <= 10)
                maxMana++;
            else
                maxMana = 10;
            UpdateManaCrystals();

            if (playerOne)
            {
                if (maxMana > 0)
                    manaCrystals[maxMana - 1].SetActive(true);
            }
        }
    }

    public void DecreaseMaxMana(int decreaseAmount)
    {
        for (int i = 0; i < decreaseAmount; i++)
        {
            if (maxMana - 1 >= 0)
                maxMana--;
            else
                maxMana = 0;

            if (currentMana > maxMana)
                currentMana = maxMana;

                UpdateManaCrystals();

            if (playerOne)
            {
                if (maxMana > 0)
                    manaCrystals[maxMana].SetActive(false);
            }
        }

    }

    private void UpdateManaCrystals()
    {
        currentManaText.text = currentMana.ToString();
        maxManaText.text = maxMana.ToString();
    }
    #endregion
    #region Turns
    public void StartTurn()
    {
        myTurn = true;
        IncreaseMaxMana(1);
        IncreaseMana(10);
    }

    public void EndTurn()
    {
        myTurn = false;
    }
    #endregion

    private void Died()
    {

    }
}
