using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour
{
    GameState currentGameState;
    public Text nameText, healthText, fatigueText, movementText;
    public Hero[] players = new Hero[4];
   // public Shader icon;
    bool updated = true;


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

        //set list of icons
       // icon[0] = GetComponentInChildren<Shader>();

    }

    void Update()
    {
        if (currentGameState == GameState.playerTurn && updated == true)
        {
            PlayerTurn();
            updated = false;
        }
        if (currentGameState == GameState.overlordTurn)
        {

        }
    }

    public void EndTurn()
    {
        if (playerTurnNo >= 3)
        {
            //playerTurnNo = 0;
            currentGameState = GameState.overlordTurn;
        }
        else
        {
            playerTurnNo++;
        }
        updated = true;
    }

    void PlayerTurn()
    {
        UpdateUIPlayer();
        //refreshCards();
        //AllowActions();
    }

    public void SetupComplete()
    {
        currentGameState = GameState.playerTurn;
    }

    void UpdateUIPlayer()
    {
        int health, maxHealth, movement, fatigue, maxFatigue;
        nameText.text = "Player " + (playerTurnNo + 1) + ": \n" + players[playerTurnNo].GetName();

        health = players[playerTurnNo].GetHealth();
        maxHealth = players[playerTurnNo].GetMaxHealth();
        movement = players[playerTurnNo].GetMovement();
        fatigue = players[playerTurnNo].GetFatigue();
        maxFatigue = players[playerTurnNo].GetMaxFatigue();

        healthText.text = health + " / " + maxHealth;
        movementText.text = movement + " / " + movement;
        fatigueText.text = fatigue + " / " + maxFatigue;

        Debug.Log(health + " " + maxHealth);


        Debug.Log("UI updated");
    }
}
