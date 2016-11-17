using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour
{
    GameState currentGameState;
    public Text nameText, healthText, fatigueText, movementText;
    public Hero[] players = new Hero[4];

    int playerTurnNo = 0;


    public enum GameState
    {
        preGame,
        playerTurn,
        overlordTurn,
        endgame
    }

    void Start()
    {
        currentGameState = GameState.preGame;
    }

    void Update()
    {

        if (currentGameState == GameState.playerTurn)
        {
            if (playerTurnNo < 3)
            {
                PlayerTurn();

            }
            else
            {
                playerTurnNo = 1;
                currentGameState = GameState.overlordTurn;
            }
        }
    }

    void PlayerTurn()
    {
        UpdateUI();
        //refreshCards();
        //AllowActions();
    }

    public void SetupComplete()
    {
        currentGameState = GameState.playerTurn;
    }

    void UpdateUI()
    {
        int health, maxHealth, movement, fatigue, maxFatigue;
        nameText.text = "Player " + (playerTurnNo + 1) + ": " + players[playerTurnNo].GetName();

        health = players[playerTurnNo].GetHealth();
        maxHealth = players[playerTurnNo].GetMaxHealth();
        movement = players[playerTurnNo].GetMovement();
        fatigue = players[playerTurnNo].GetFatigue();
        maxFatigue = players[playerTurnNo].GetMaxFatigue();

        healthText.text = health + " / " + maxHealth;




        //playerTurnNo++;
    }
}
