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
    public Hero Players;
    string filePath, info;
    int count = 0;

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

    void Start()
    {
        for (int i = 3; i >= 0; i--)
        {
            available[i] = false;
        }

        filePath = "URI=file:" + Application.dataPath + "Minions.s3db";
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
        Debug.Log("Warrior Selected");
        available[0] = true;
        if (champ == true)
        {
            // info = "INSERT INTO Hero's Values (" + count.ToString() + ", '" + 
        }
        else
        {
            //output to database instead
        }
    }

    public void HealerSelect()
    {
        string sub;
        Debug.Log("Healer Selected");
        available[1] = true;
        if (option == true)
        {
            sub = "SpiritSeer";
        }
        else
        {
            sub = "";
        }
        if (champ == true)
        {
            //      Players.AvricSelect(option);        //output to database instead
            info = "INSERT INTO Hero's Values (" + count.ToString() + " ', ' Avric ', ' Mage ', ' " + sub;
        }
        else
        {
            //Players.AsharianSelect(option);     //output to database instead
            info = "INSERT INTO Hero's Values (" + count.ToString() + " ', ' Asharian ', ' Mage ', ' " + sub;
        }
        InsertIntoMinionTable(info);
    }

    public void MageSelect()
    {
        string sub;
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
            info = "INSERT INTO Hero's Values (" + count.ToString() + " ', ' Leoric ', ' Mage ', ' " + sub;
        }
        else
        {
            // Players.WidowSelect(option);         //output to database instead
            info = "INSERT INTO Hero's Values (" + count.ToString() + " ', ' Widow ', ' Mage ', ' " + sub;
        }
        InsertIntoMinionTable(info);
    }

    public void ScoutSelect()
    {
        Debug.Log("Scout Selected");
        available[3] = true;
        if (champ == true)
        {
            //output to database instead
        }
        else
        {
            //output to database instead
        }
    }
}
