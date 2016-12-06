﻿using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    GameState currentGameState;
    public Text nameText, healthText, fatigueText, movementText;
    public Hero[] players = new Hero[4];
    // public Shader icon;
    bool updated = true, action = false;
    int actionsLeft = 2, moveTemp;
    public Dropdown drop;

    public int GetPlayerTurnNo()
    {
        return playerTurnNo;
    }

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
        drop.value = 0;
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
            UpdateOverLoadUI();
        }
        if (action)
        {
            players[playerTurnNo].SetActions(moveTemp, playerTurnNo);
            action = false;
        }
    }
    public void EndTurn()
    {
        if (currentGameState == GameState.overlordTurn)
        {
            currentGameState = GameState.playerTurn;
        }
        else if (playerTurnNo >= 3)
        {
            //playerTurnNo = 0;
            currentGameState = GameState.overlordTurn;
            playerTurnNo = 0;
        }
        else
        {
            playerTurnNo++;
        }
        updated = true;
        drop.value = 0;
        actionsLeft = 2;
    }

    void PlayerTurn()
    {
        actionsLeft = 2;
        UpdateUIPlayer();
        drop.interactable = true;
        //refreshCards();
    }

    public void SetupComplete()
    {
        currentGameState = GameState.playerTurn;
    }

    void UpdateOverLoadUI()
    {
        nameText.text = "OVERLord turn";
        healthText.text = "Blah";
        movementText.text = "hehe";
        fatigueText.text = "workz";
    }

    void UpdateUIPlayer()
    {
        int health, maxHealth, movement, fatigue, maxFatigue;
        nameText.text = "Player " + (playerTurnNo + 1) + ": \n" + players[playerTurnNo].GetName();

        health = players[playerTurnNo].GetHealth();
        maxHealth = players[playerTurnNo].GetMaxHealth();
        movement = players[playerTurnNo].GetMovement();
        moveTemp = movement;
        fatigue = players[playerTurnNo].GetFatigue();
        maxFatigue = players[playerTurnNo].GetMaxFatigue();

        healthText.text = health + " / " + maxHealth;
        movementText.text = movement + " / " + movement;
        fatigueText.text = fatigue + " / " + maxFatigue;

        Debug.Log(health + " " + maxHealth);


        Debug.Log("UI updated");
    }

    void AllowActions()
    {
        int value = drop.value;
        switch (value)
        {
            case 1:
                Debug.Log("Atttcking");                                 //get the minion being attacked
                //players[playerTurnNo];
                break;
            case 2:
                action = true;
                Debug.Log("MOVE PLS YOU ARSE");
                // players[playerTurnNo].Move(moveTemp);
                break;
            case 3:
                players[playerTurnNo].Rest();
                break;
            case 4:
                Debug.Log("HAHA YOU DROPPED NOTHING :D");
                break;
            default:
                Debug.Log("It's fucked / doing another actions that isnt' defined yet :3 ");
                break;
        }
        if (actionsLeft <= 0)
        {
            drop.interactable = false;
            EndTurn();
        }
    }

    public void Actions()
    {
        actionsLeft--;
        AllowActions();
    }
}
