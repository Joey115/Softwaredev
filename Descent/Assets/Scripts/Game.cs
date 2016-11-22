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
    int actionsLeft = 2;
    public Dropdown drop;


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
        drop.interactable = false;

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
        drop.interactable = true;
        //refreshCards();
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

    public void AllowActions(int value)
    {
        switch (value)
        {
            case 1:
                players[playerTurnNo].Attack();
                Debug.Log("Atttcking");
                break;
            case 2:
                int temp = players[playerTurnNo].GetMovement();
                players[playerTurnNo].Move(temp);
                break;
            default:
                Debug.Log("It's fucked");
                break;
        }
        drop.interactable = false;

        if (actionsLeft == 0)
        {
            EndTurn();
        }
    }

    public void ACtions()
    {
        actionsLeft--;
    }
}
