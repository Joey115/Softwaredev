using UnityEngine;
using UnityEditor;
using System.Collections;

public class setup : MonoBehaviour
{
    //setup ask for no of players, then create the amount of hero's necessary 
    //array of hero's
    //have a set of states for settting up, inc menu states. class, character and sub class select screen
    //could have add players until finished. with note to allow for the OVERLORD

    int noOfPlayers;
    bool option, champ;

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

    public void Champ1()
    {
        champ = true;
    }

    public void Champ2()
    {
        champ = false;
    }

    public void WarriorSelect()
    {

    }

    public void HealerSelect()
    {

    }

    public void MageSelect()
    {
        //display the 2 mage characters
        //choose a character isLeoric = option;
        //choose a subclass isRune = option;

        if (champ == true)
        {
            Players.LeoricSelect(option);
        }
        else
        {
            Players.WidowSelect(option);
        }
    }

    public void ScoutSelect()
    {

    }
}
