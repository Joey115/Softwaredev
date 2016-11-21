using UnityEngine;
using System.Collections;
using Mono.Data.SqliteClient;
using System.Data;
using System;

public class LoadHero : MonoBehaviour
{
    string filePath;
    string[] totalHeroNames = new string[4];
    string[] totalHeroClass = new string[4];
    string[] totalHeroSubClass = new string[4];
    int[] maxHealth = new int[4], movement = new int[4], maxFatigue = new int[4], might = new int[4],
        knowledge = new int[4], willpower = new int[4], awareness = new int[4];

    void Awake()
    {
        filePath = "URI=file:" + Application.dataPath + "Minions.s3db";
        GetNames();
    }


    void GetNames()
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

    public int GetMaxHealth(int playerNumber)
    {
        return maxHealth[playerNumber];
    }
    public int GetMovement(int playerNumber)
    {
        return movement[playerNumber];
    }
    public int GetMaxFatigue(int playerNumber)
    {
        return maxFatigue[playerNumber];
    }
    public int GetMight(int playerNumber)
    {
        return might[playerNumber];
    }
    public int GetKnowledge(int playerNumber)
    {
        return knowledge[playerNumber];
    }
    public int GetWillpower(int playerNumber)
    {
        return willpower[playerNumber];
    }
    public int GetAwareness(int playerNumber)
    {
        return awareness[playerNumber];
    }


    public void AttachHero(int playerNumber)
    {
        Debug.Log("Attaching Hero" + (playerNumber + 1));
        using (IDbConnection connection = new SqliteConnection(filePath))
        {
            connection.Open();
            string commandText = "SELECT * FROM HeroPresets WHERE Name='" + totalHeroNames[playerNumber] + "' ";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                maxHealth[playerNumber] = Convert.ToInt32(reader.GetValue(1));
                movement[playerNumber] = Convert.ToInt32(reader.GetValue(2));
                maxFatigue[playerNumber] = Convert.ToInt32(reader.GetValue(3));
                might[playerNumber] = Convert.ToInt32(reader.GetValue(4));
                knowledge[playerNumber] = Convert.ToInt32(reader.GetValue(5));
                willpower[playerNumber] = Convert.ToInt32(reader.GetValue(6));
                awareness[playerNumber] = Convert.ToInt32(reader.GetValue(7));
            }
        }
    }
}
