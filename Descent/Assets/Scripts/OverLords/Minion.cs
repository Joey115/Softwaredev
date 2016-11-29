using UnityEngine;
using System.Collections;
using Mono.Data.SqliteClient;
using System.Data;
using System;

public class Minion : Actions
{
    string _name, filePath;
    int _noOfMinions, _defence, _health, _movement, extraAttck;

    enum MinionTypes
    {
        ShadowDragons,
        GoblinArchers,
        CaveSpiders,
        Ettins,
    }

    public int GetDefence()
    {
        return _defence;
    }

    public override void Damaged(int temp)
    {
        _health -= temp;
    }
    public Minion(string name, int noOfMinions)
    {
        _name = name;
        _noOfMinions = noOfMinions;

    }

    public void Start()
    {
        MinionTypes thisMinion = MinionTypes.GoblinArchers;
        filePath = "URI=file:" + Application.dataPath + "Minions.s3db";
        _name = thisMinion.ToString();
        LoadMinions();
        //instantiate children
    }

    public void LoadMinions()
    {
        using (IDbConnection connection = new SqliteConnection(filePath))                           //REWRITE TO DO THE CORRECT WAY ROUND - ARSE
        {
            connection.Open();
            string commandText = "SELECT * FROM Minions WHERE name='" + _name + "'";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                _noOfMinions = Convert.ToInt32(reader.GetValue(1));
                _health = Convert.ToInt32(reader.GetValue(2));
                _movement = Convert.ToInt32(reader.GetValue(4));
                _defence = Convert.ToInt32(reader.GetValue(5));
                extraAttck = Convert.ToInt32(reader.GetValue(6));
            }
        }
    }

    public override void Special()
    {

    }
}
