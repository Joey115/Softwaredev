using UnityEngine;
using System.Data;
using System;


public class Hero : Actions
{

    /*
        4 classes(warrior, mage, healer, scout) + 2 subclasses(knight/beserker, necromancer/runemaster, 
        thief/? , 

        so select hero / select a class first? then allow them to choose their subclass

    */

    //general stats variable if we can do inheritance + taken damage or fatigue functions

    int health, maxHealth, movement, fatigue, maxFatigue, might, knowledge, willpower, awareness; //standard hero attritbutes
    int playerNumber;
    public Game game = new Game();
    public LoadHero load = new LoadHero();
    string heroName, heroClass, heroSub;


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


    public void Start()
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


    }

    public void Fatigued()                                     //taken fatigue point
    {
        fatigue--;
    }
    public void Damaged(int damage)                                     //taken damage point
    {
        health -= damage;
    }
}
