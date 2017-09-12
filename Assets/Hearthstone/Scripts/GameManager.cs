using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerOneHeroPosition;
    public Transform playerTwoHeroPosition;

    public GameObject playerOne;
    public GameObject playerTwo;

    private void Start()
    {
        CreatePlayers();
    }

    private void CreatePlayers()
    {
        Instantiate(playerOne, playerOneHeroPosition.position, Quaternion.identity, playerOneHeroPosition);
        Instantiate(playerTwo, playerTwoHeroPosition.position, Quaternion.identity, playerTwoHeroPosition);
    }
}
