using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
    void Done()
    {
       // List<Hero> Heros = new List<Hero>();
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

    public void WarriorSelect()
    {
        Debug.Log("Warrior Selected");
        available[0] = true;
        if (champ == true)
        {
                 //output to database instead
        }
        else
        {
                //output to database instead
        }
    }

    public void HealerSelect()
    {
        Debug.Log("Healer Selected");
        available[1] = true;
        if (champ == true)
        {
            Players.AvricSelect(option);        //output to database instead
        }
        else
        {
            Players.AsharianSelect(option);     //output to database instead
        }
    }

    public void MageSelect()
    {
        Debug.Log("Mage Selected");
        available[2] = true;
        if (champ == true)
        {
            Players.LeoricSelect(option);        //output to database instead
        }
        else
        {
            Players.WidowSelect(option);         //output to database instead
        }
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
