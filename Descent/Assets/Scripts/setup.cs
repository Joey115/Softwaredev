using UnityEngine;
using System.Collections;

public class setup
{
    //setup ask for no of players, then create the amount of hero's necessary 
    //array of hero's
    //have a set of states for settting up, inc menu states. class, character and sub class select screen
    //could have add players until finished. with note to allow for the OVERLORD

    int noOfPlayers;
    bool option;

    Hero Players = new Hero();

    void Start()
    {
        //work out noOfPlayers;
    }

    void CreatePlayers()
    {
        for (int i = 0; i <= noOfPlayers; i++)
        {
            //Hero playerHero[i] = new Hero();
        }
    }

    public void OnOption2Select()
    {
        option = false;
    }

    public void OnOption1Select()
    {
        option = true;
    }

    void WarriorSelect()
    {

    }

    void HealerSelect()
    {

    }

    void MageSelect()
    {
        bool isLeoric, isRune;
        //display the 2 mage characters
        //choose a character isLeoric = option;
        //choose a subclass isRune = option;

       if (isLeoric == true)
        {
            Players.LeoricSelect(isRune);
        }
    }

    void ScoutSelect()
    {

    }
}
