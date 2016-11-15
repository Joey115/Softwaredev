using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Mono.Data.SqliteClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

public class setup : MonoBehaviour
{
    //setup ask for no of players, then create the amount of hero's necessary 
    //array of hero's
    //have a set of states for settting up, inc menu states. class, character and sub class select screen
    //could have add players until finished. with note to allow for the OVERLORD

    bool option, champ;
    public Button[] heroBut = new Button[4];
    bool[] available = new bool[4];
   // public Hero Players;
    string filePath;
    int count = 1;

    public void OnOption2Select()
    {
        option = false;
    }
    public void OnOption1Select()
    {
        option = true;
    }
    public void Champ1()
    {
        champ = true;
    }
    public void Champ2()
    {
        champ = false;
    }

    void DeleteTable()
    {
        using (IDbConnection connection = new SqliteConnection(filePath))
        {
            connection.Open();
            string commandText = "DROP TABLE IF EXISTS Heros ";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            command.ExecuteNonQuery();
            Debug.Log("Deleted Table named Heros in Minions");
        }
    }
    void CreateTable()
    {
        using (IDbConnection connection = new SqliteConnection(filePath))
        {
            connection.Open();
            string commandText = "CREATE TABLE Heros (ID INT UNIQUE PRIMARY KEY, Name TEXT, Class TEXT, SubClass Text)";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            command.ExecuteNonQuery();
            Debug.Log("Created a new table named Heros in Minions");
        }
    }

    void Start()
    {
        for (int i = 3; i >= 0; i--)
        {
            available[i] = false;
        }

        filePath = "URI=file:" + Application.dataPath + "Minions.s3db";
        DeleteTable();
        CreateTable();
    }


    public void ConfirmClick()
    {
        for (int i = 3; i >= 0; i--)
        {
            if (available[i] == false)
            {
                Debug.Log(i);
                heroBut[i].interactable = true;
            }
        }
    }
    public void SelectedHero()
    {
        for (int i = 3; i >= 0; i--)
        {
            if (available[i] == false)
            {
                heroBut[i].interactable = false;
            }
        }
    }

    void InsertIntoMinionTable(string info)
    {
        using (IDbConnection connection = new SqliteConnection(filePath))
        {
            connection.Open();
            IDbCommand command = connection.CreateCommand();
            command.CommandText = info;
            command.ExecuteNonQuery();
            Debug.Log("Inserted a new Hero");
            count++;
        }
    }


    //when Count == 4 finish the character select and move onto which encounter is going to start.


    public void WarriorSelect()
    {
        string sub, info;
        Debug.Log("Warrior Selected");
        available[0] = true;
        if (option == true)
        {
            sub = " Beserker";
        }
        else
        {
            sub = "Knight";
        }

        if (champ == true)
        {
            info = "INSERT INTO Heros VALUES ('" + count.ToString() + " ', ' Grisban the thirsty', ' Warrior ', ' " + sub + "');";
        }
        else
        {
            info = "INSERT INTO Heros VALUES ('" + count.ToString() + " ', ' Syndrael', ' Warrior ', ' " + sub + "');";
        }
        InsertIntoMinionTable(info);
    }

    public void HealerSelect()
    {
        string sub, info;
        Debug.Log("Healer Selected");
        available[1] = true;
        if (option == true)
        {
            sub = "SpiritSeaker";
        }
        else
        {
            sub = "Disciple";
        }
        if (champ == true)
        {
            //      Players.AvricSelect(option);        //output to database instead
            info = "INSERT INTO Heros VALUES ('" + count.ToString() + " ', ' Avric Albright', ' Healer ', ' " + sub + "');";
        }
        else
        {
            //Players.AsharianSelect(option);     //output to database instead
            info = "INSERT INTO Heros VALUES ('" + count.ToString() + " ', ' Asharian ', ' Healer ', ' " + sub + "');";
        }
        InsertIntoMinionTable(info);
    }

    public void MageSelect()
    {
        string sub, info;
        Debug.Log("Mage Selected");
        available[2] = true;

        if (option == true)
        {
            sub = "Runemaster";
        }
        else
        {
            sub = "Necromancer";
        }

        if (champ == true)
        {
            //Players.LeoricSelect(option);        //output to database instead
            info = "INSERT INTO Heros VALUES ('" + count.ToString() + "' ,  'Leoric of the Book' ,  'Mage' ,  '" + sub + "');";
        }
        else
        {
            // Players.WidowSelect(option);         //output to database instead
            info = "INSERT INTO Heros VALUES ('" + count.ToString() + "' ,  'Widow Tahra' , 'Mage' ,  '" + sub + "');";
        }
        InsertIntoMinionTable(info);
    }

    public void ScoutSelect()
    {
        string sub, info;
        Debug.Log("Scout Selected");
        available[3] = true;
        if (option == true)
        {
            sub = "Thief";
        }
        else
        {
            sub = "Wildlander";
        }
        if (champ == true)
        {
            info = "INSERT INTO Heros VALUES ('" + count.ToString() + "' , ' Tomble Burrowelll ', ' Scount ', ' " + sub + "');";
        }
        else
        {
            info = "INSERT INTO Heros VALUES ('" + count.ToString() + " ', ' Jain Fairwood ', ' Scout ', ' " + sub + "');";
        }
        InsertIntoMinionTable(info);
    }
}
