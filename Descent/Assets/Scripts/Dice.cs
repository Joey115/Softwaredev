using UnityEngine;
using System.Collections;

public class Dice
{
    int valMin, valMax;

    /*
        Heart = point of damage
        Lightning = surge ability
        X = miss
        2-6 = extra range
        shield = damage blocked
    */

    //attack dice
    enum blueDie { _Cross = 1, _2A2HeartALight = 2, _3A2Heart = 3, _4A2Heart = 4, _5A1Heart = 5, _6AHeartAlight = 6 };
    //power die
    enum redDie { _2Heart = 1, _1Heart = 2, _3Heart = 3, _3HeartLight = 4 };
    enum yellowDie { _1Light = 1, _1Heart = 2, _2Aheart = 3, _heartAlight = 4, _2hearts = 5, _2HeartsLight = 6 };
    //defence die
    enum greyDie { _1Shield = 1, _0Shield = 2, _2Shield = 3, _3Shield = 4 };
    enum blackDie { _2Shield = 1, _1Shield = 2, _3Shield = 3, _4Shield = 4 };
    enum brownDie { _Blank = 1, _1Shield = 2, _2Shield = 3 };
   
    public Dice()
    {
        valMin = 1;
        valMax = 6;
    }

    public int rollType3Die()                      //Yellow or blue
    {
        int diceRoll;
        diceRoll = RollDice();
        return diceRoll;
    }

    public int rollType2Die()                       //brown die
    {
        int diceRoll;
        diceRoll = RollDice();

        if (diceRoll <= 3)
        { return 1; }
        else
        if (diceRoll == 4 || diceRoll == 5)
        { return 2; }
        else
        if (diceRoll == 6)
        { return 3; }

        else return 1;
    }

    public int rollType1Die()                       //grey, black & red use same function
    {
        int diceRoll;
        diceRoll = RollDice();

        if (diceRoll <= 3)
        { return 1; }
        else
        if (diceRoll == 4)
        { return 2; }
        else
        if (diceRoll == 5)
        { return 3; }
        else
        if (diceRoll == 6)
        { return 4; }
        else return 1;
    }


    int RollDice()
    {
        return Random.Range(valMin, valMax);
    }
}
