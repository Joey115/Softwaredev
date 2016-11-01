using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class setup : MonoBehaviour
{
    //setup ask for no of players, then create the amount of hero's necessary 
    //array of hero's
    //have a set of states for settting up, inc menu states. class, character and sub class select screen
    //could have add players until finished. with note to allow for the OVERLORD

    int noOfPlayers;
    bool option, champ;
    public Button[] heroBut = new Button[4];
    bool[] available = new bool[4]; 
    Hero Players = new Hero();

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

    void Awake()
    {
        for (int i = 3; i >= 0; i--)
        {
            available[i] = false;
        }
    }
    public void ConfirmClick()
    {
        for (int i = 3; i >= 0; i--)
        {
            if (available[i] == false)
            {
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

    public void WarriorSelect()
    {
        available[0] = true;
    }

    public void HealerSelect()
    {
        available[1] = true;
    }

    public void MageSelect()
    {
        available[2] = true;
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
        available[3] = true;
    }
}
