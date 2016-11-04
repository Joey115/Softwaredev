using UnityEngine;
using System.Collections;

public class Leoric : Hero
{

    public Leoric(bool isRune)
    {
        health = 8;
        movement = 4;
        fatigue = 5;

        if (isRune == true)
        {
            IsRuneMaster();
        }
        else { IsNecromancer(); }
    }

    void IsRuneMaster()
    {

    }

    void IsNecromancer()
    {

    }

}
