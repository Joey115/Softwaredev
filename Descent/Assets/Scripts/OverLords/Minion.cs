using UnityEngine;
using System.Collections;

public class Minion : Actions
{
    string _name;
    int _noOfMinions, defence, health, movement;

    enum MinionTypes
    {
        ShadowDragons,
        GoblinArchers,
        CaveSpiders,
    }

    public int GetDefence()
    {
        return defence;
    }

    public override void Damaged(int temp)
    {
        health -= temp;
    }
    public Minion(string name, int noOfMinions)
    {
        _name = name;
        _noOfMinions = noOfMinions;
        LoadMinions();
    }

    public void LoadMinions()
    {

    }

    public override void Special()
    {

    }
}
