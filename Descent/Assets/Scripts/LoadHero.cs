using UnityEngine;
using System.Collections;
using Mono.Data.SqliteClient;
using System.Data;
using System;

public class LoadHero
{
    string filePath;
    string[] totalHeroNames = new string[4];
    string[] totalHeroClass = new string[4];
    string[] totalHeroSubClass = new string[4];

    void Start()
    {
        filePath = "URI=file:" + Application.dataPath + "Minions.s3db";
        GetHeroNames();
    }


    void GetHeroNames()
    {
        Debug.Log("Getting heros names");
        int i = 3;
        using (IDbConnection connection = new SqliteConnection(filePath))                           //REWRITE TO DO THE CORRECT WAY ROUND - ARSE
        {
            connection.Open();
            string commandText = "SELECT * FROM Heros";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                totalHeroNames[i] = Convert.ToString(reader.GetValue(0));
                totalHeroClass[i] = Convert.ToString(reader.GetValue(1));
                totalHeroSubClass[i] = Convert.ToString(reader.GetValue(2));
                i--;
            }
        }
    }


    public string GetHeroName(int playerNumber)
    {
        return totalHeroNames[playerNumber];
    }
    public string GetHeroClass(int playerNumber)
    {
        return totalHeroClass[playerNumber];
    }
    public string GetHeroSubClass(int playerNumber)
    {
        return totalHeroSubClass[playerNumber];
    }


    public void AttachHero(int playerNumber)
    {
        int maxHealth, movement, maxFatigue, might, knowledge, willpower, awareness;

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

    }

}
