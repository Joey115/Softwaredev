using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.SqliteClient;
using System.Linq;
using System.Text;
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

    protected int health, movement, fatigue, might, knowledge, willpower, awareness; //standard hero attritbutes
    string filePath = "URI=file:" + Application.dataPath + "Minions.s3db";

    enum CharacterState
    {
        RefreshState,
        Actions,
        notTurn
    }

    int[] ID = new int[4];
    string[] heroName = new string[4];
    string[] heroClass = new string[4];
    string[] heroSub = new string[4];

    public void GetHero()
    {
        int i = 0;
        using (IDbConnection connection = new SqliteConnection(filePath))
        {
            connection.Open();
            string commandText = "SELECT * FROM Heros";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ID[i] = Convert.ToInt32(reader.GetValue(1));
                heroName[i] = Convert.ToString(reader.GetValue(2));
                heroClass[i] = Convert.ToString(reader.GetValue(3));
                heroSub[i] = Convert.ToString(reader.GetValue(4));
                i++;
            }
        }
    }

    void CheckHero(int player)
    {
     if(heroName[player] == "Widow Tahra")
        {

        }
    }

    public void Start()
    {
        GetHero();
        switch (this.name)
        {
            case "Player1":
                //read ID 1 from the database - check player.
                CheckHero(1);
                break;
            case "Player2":
                CheckHero(2);
                break;
            case "Player3":
                CheckHero(3);
                break;
            case "Player4":
                CheckHero(4);
                break;
            default:
                Debug.Log("Cannot read the player, no Hero Selected Arsehat");
                break;
        }

    }

    void DisplayActions()
    {

    }

    public void Fatigued()                                     //taken fatigue point
    {
        fatigue--;
    }

    public void Damaged(int damage)                                     //taken damage point
    {
        health -= damage;
    }

    public void LeoricSelect(bool _isRune)                  //Leoric champion selected + subclass selection added
    {
        Leoric leoricHero = new Leoric(_isRune);
    }

    public void WidowSelect(bool _isRune)
    {
        Widow widowHero = new Widow(_isRune);
    }

    public void AsharianSelect(bool _isSeer)
    {
        Ashrian ashrianHero = new Ashrian(_isSeer);
    }

    public void AvricSelect(bool _isSeer)
    {

    }
}
