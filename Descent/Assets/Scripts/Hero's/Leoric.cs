using UnityEngine;
using System.Collections;

public class Leoric : Hero
{

    public Leoric(bool isRune)
    {
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
