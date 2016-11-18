using UnityEngine;
using System.Data;
using System;

using Mono.Data.SqliteClient;

public class Hero : Actions
{

    /*
        4 classes(warrior, mage, healer, scout) + 2 subclasses(knight/beserker, necromancer/runemaster, 
        thief/? , 

        so select hero / select a class first? then allow them to choose their subclass

    */

    //general stats variable if we can do inheritance + taken damage or fatigue functions

    protected int health, maxHealth, movement, fatigue, maxFatigue, might, knowledge, willpower, awareness; //standard hero attritbutes
    int playerNumber;
    public Game game = new Game();
    string heroName, heroClass, heroSub, filePath;
    string[] totalHeroNames = new string[8];

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
        return totalHeroNames[playerNumber];  //heroName;
    }

    enum CharacterState
    {
        RefreshState,
        Actions,
        notTurn
    }

    public void GetHero()
    {
        using (IDbConnection connection = new SqliteConnection(filePath))
        {
            connection.Open();
            string commandText = "SELECT * FROM Heros WHERE Name='" + totalHeroNames[playerNumber] + "' ";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                heroName = Convert.ToString(reader.GetValue(1));
                heroClass = Convert.ToString(reader.GetValue(2));
                heroSub = Convert.ToString(reader.GetValue(3));
                Debug.Log(heroName + " " + heroClass + " " + heroSub);
            }

            if (heroName != totalHeroNames[playerNumber])
            {
                Debug.Log("Player" + playerNumber + " is not equal to reference");
            }
        }
        AttachHero();
    }
    void GetHeroNames()
    {
        Debug.Log("Getting heros names");
        int i = 7;
        using (IDbConnection connection = new SqliteConnection(filePath))
        {
            connection.Open();
            string commandText = "SELECT Name FROM HeroPresets";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                totalHeroNames[i] = Convert.ToString(reader.GetValue(0));
                i--;
            }
        }
    }
    void AttachHero()
    {
        Debug.Log("Attaching Hero" + playerNumber);
        using (IDbConnection connection = new SqliteConnection(filePath))
        {
            connection.Open();
            string commandText = "SELECT * FROM HeroPresets WHERE Name='" + totalHeroNames[playerNumber] + "' ";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                maxHealth = Convert.ToInt32(reader.GetValue(1));
                movement = Convert.ToInt32(reader.GetValue(2));
                maxFatigue = Convert.ToInt32(reader.GetValue(3));
                might = Convert.ToInt32(reader.GetValue(4));
                knowledge = Convert.ToInt32(reader.GetValue(5));
                willpower = Convert.ToInt32(reader.GetValue(6));
                awareness = Convert.ToInt32(reader.GetValue(7));
            }
        }
        health = maxHealth;
        fatigue = 0;

        if (game != null)
        {
            //change state
            Debug.Log("Setup is complete");
            game.SetupComplete();
        }
    }

    public void Start()
    {
        filePath = "URI=file:" + Application.dataPath + "Minions.s3db";
        GetHeroNames();
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
        GetHero();
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
