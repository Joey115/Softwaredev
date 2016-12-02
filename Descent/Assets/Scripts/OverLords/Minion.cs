using UnityEngine;
using Mono.Data.SqliteClient;
using System.Data;
using System;

public class Minion : Actions
{
    protected string _name, filePath;
    protected int _noOfMinions, _defence, _health, _masterHealth, _movement, extraAttck;
    protected bool master = false;

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
        if (master == false)
        {
            _health -= temp;
            if (_health <= 0)
            {
                Destroy(this);
            }
        }
        else
        {
            _masterHealth -= temp;
            if (_masterHealth <= 0)
            {
                Destroy(this);
            }
        }
    }

    public void Start()
    {
        MinionTypes thisMinion = MinionTypes.GoblinArchers;
        filePath = "URI=file:" + Application.dataPath + "Minions.s3db";
        _name = thisMinion.ToString();
        LoadMinions();
        //instantiate children
    }

    void LoadMinions()
    {
        using (IDbConnection connection = new SqliteConnection(filePath))
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
                _masterHealth = Convert.ToInt32(reader.GetValue(3));
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
