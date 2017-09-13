using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("Player Variables")]
    public Transform playerOneHeroPosition;
    public Transform playerTwoHeroPosition;

    public GameObject playerOne;
    public GameObject playerTwo;

    public GameObject[] manaCrystals;

    [Space, Header("Testing Variables")]
    public MonsterCard monsterCard;


    Hero playerOneHero;
    Hero playerTwoHero;

    Hero currentPlayer;
    Coroutine startTurn;

    private void Start()
    {
        CreatePlayers();
        startTurn = StartCoroutine(StartTurn());
    }

    private void CreatePlayers()
    {
        playerOneHero = Instantiate(playerOne, playerOneHeroPosition.position, Quaternion.identity, playerOneHeroPosition).GetComponent<Hero>();
        playerTwoHero = Instantiate(playerTwo, playerTwoHeroPosition.position, Quaternion.identity, playerTwoHeroPosition).GetComponent<Hero>();

        playerOneHero.playerOne = true;
        playerOneHero.manaCrystals = manaCrystals;
        currentPlayer = playerOneHero;
    }

    IEnumerator StartTurn()
    {
        yield return new WaitForSeconds(1);
        currentPlayer.StartTurn();
        yield return new WaitForSeconds(75);
        currentPlayer.EndTurn();

        if (currentPlayer == playerOneHero)
            currentPlayer = playerTwoHero;
        else
            currentPlayer = playerOneHero;
    }

    #region TestMethods

#region ManaCrystalTesting
    public void IncreaseMana()
    {
        playerOneHero.IncreaseMana(2);
    }

    public void DecreaseMana()
    {
        playerOneHero.DecreaseMana(3);
    }

    public void IncreaseMaxMana()
    {
        playerOneHero.IncreaseMaxMana(2);
    }

    public void DecreaseMaxMana()
    {
        playerOneHero.DecreaseMaxMana(3);
    }

    public void StartPlayerTurn()
    {
        playerOneHero.StartTurn();
    }
#endregion

    public void GainHealth(int healthGained)
    {
        monsterCard.GainHealth(healthGained);
    }

    public void LoseHealth(int healthLost)
    {
        monsterCard.LoseHealth(healthLost);
    }

    public void SetHealthTo(int setHealthTo)
    {
        monsterCard.SetHealth(setHealthTo);
    }

    public void GainMaxHealth(int maxHealthGained)
    {
        monsterCard.GainMaxHealth(maxHealthGained);
    }

    public void GainAttack(int attackGained)
    {
        monsterCard.IncreaseAttack(attackGained);
    }

    public void LoseAttack(int attackLost)
    {
        monsterCard.DecreaseAttack(attackLost);
    }

    public void SetAttackTo(int setAttackTo)
    {
        monsterCard.SetAttack(setAttackTo);
    }

    public void IncreaseManaCost(int manaIncrease)
    {
        monsterCard.IncreaseManaCost(manaIncrease);
    }

    public void DecreaseManaCost(int manaDecrease)
    {
        monsterCard.ReduceManaCost(manaDecrease);
    }

    public void SetManaTo(int setManaTo)
    {
        monsterCard.SetManaCost(setManaTo);
    }

    #endregion
}
