using UnityEngine;
using System.Collections;

public class Widow : Hero
{
    public Widow(bool isRune)
    {
        health = 10;
        movement = 4;
        fatigue = 4;

        if (isRune == true)
        {
            IsRuneMaster();
        }
        else { IsNecromancer(); }
    }

    void IsRuneMaster()
    {
        //specialist skills and abilities
    }

    void IsNecromancer()
    {

    }
}
