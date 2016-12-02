using UnityEngine;
using System.Data;
using System;


public class Hero : Actions
{
    //general stats variable if we can do inheritance + taken damage or fatigue functions

    int health, maxHealth, movement, fatigue = 0, maxFatigue, might, knowledge, willpower, awareness; //standard hero attritbutes
    int playerNumber;
    public Game game;
    public LoadHero load;
    public string heroName, heroClass, heroSub;


    public int GetHealth()
    {
        return health;
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public int GetMovement()
    {
        return movement;
    }
    public int GetFatigue()
    {
        return fatigue;
    }
    public int GetMaxFatigue()
    {
        return maxFatigue;
    }
    public string GetName()
    {
        return heroName;  //heroName;
    }

    enum CharacterState
    {
        RefreshState,
        Actions,
        notTurn
    }

    void Start()
    {
        switch (this.gameObject.name)
        {
            case "Player1":
                //read ID 1 from the database - check player.
                playerNumber = 0;
                Debug.Log("Hero 1 found");
                break;
            case "Player2":
                playerNumber = 1;
                Debug.Log("Hero 2 found");
                break;
            case "Player3":
                playerNumber = 2;
                Debug.Log("Hero 3 found");
                break;
            case "Player4":
                playerNumber = 3;
                Debug.Log("Hero 4 found");
                break;
            default:
                Debug.Log("Cannot read the player, no Hero Selected Arsehat");
                break;
        }
        SetupHeros();
        health = maxHealth;
        Debug.Log(heroName);
    }

    bool check = false;
    void LateUpdate()
    {
        if (game != null && check == false)
        {
            //change state
            Debug.Log("Setup is complete");
            game.SetupComplete();
            check = true;
        }
    }

    void SetupHeros()
    {
        heroName = load.GetHeroName(playerNumber);
        heroClass = load.GetHeroClass(playerNumber);
        heroSub = load.GetHeroSubClass(playerNumber);
        maxHealth = load.GetMaxHealth(playerNumber);
        movement = load.GetMovement(playerNumber);
        maxFatigue = load.GetMaxFatigue(playerNumber);
        might = load.GetMight(playerNumber);
        knowledge = load.GetKnowledge(playerNumber);
        willpower = load.GetWillpower(playerNumber);
        awareness = load.GetAwareness(playerNumber);
    }

    public override void Special()
    {
        // insert special abilities here.
    }

    public void Rest()
    {
        fatigue = 0;
        Debug.Log("Rested player");
    }
    public void Fatigued()                                     //taken fatigue point
    {
        fatigue++;
    }
    public override void Damaged(int damage)                                     //taken damage point
    {
        health -= damage;
    }

    int additional()
    {
        return 0;
    }
}
