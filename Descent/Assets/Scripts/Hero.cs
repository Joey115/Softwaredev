using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hero
{

    /*
        4 classes(warrior, mage, healer, scout) + 2 subclasses(knight/beserker, necromancer/runemaster, 
        thief/? , 

        so select hero / select a class first? then allow them to choose their subclass

    */

    //general stats variable if we can do inheritance + taken damage or fatigue functions

    int movement, health, fatigue;

    public Hero() {}

    public Hero(int heroClass)
    {
        if (heroClass == 1)
        {
            Warriorclass();
        }
        else if (heroClass == 2)
        {
            MageClass();
        }
        else if (heroClass == 3)
        {
            HealerClass();
        }
        else
        {
            ScoutClass();
        }
    }

    void Warriorclass()
    {

    }

    void MageClass()
    {
        Leoric mage = new Leoric();
    }

    void HealerClass()
    {

    }

    void ScoutClass()
    {

    }

}
