using UnityEngine;
using System.Collections;

public class Dice
{
    int range, damage, valMin, valMax;
    bool surge = false, miss = false;

    /*
        Heart = point of damage
        Lightning = surge ability
        X = miss
        2-6 = extra range
        shield = damage blocked

    //attack dice
    enum blueDie { _Cross = 1, _2A2HeartALight = 2, _3A2Heart = 3, _4A2Heart = 4, _5A1Heart = 5, _6AHeartAlight = 6 };
    //power die
    enum redDie { _2Heart = 1, _1Heart = 2, _3Heart = 3, _3HeartLight = 4 };
    enum yellowDie { _1Light = 1, _1Heart = 2, _2Aheart = 3, _heartAlight = 4, _2hearts = 5, _2HeartsLight = 6 };
    //defence die
    enum greyDie { _1Shield = 1, _0Shield = 2, _2Shield = 3, _3Shield = 4 };
    enum blackDie { _2Shield = 1, _1Shield = 2, _3Shield = 3, _4Shield = 4 };
    enum brownDie { _Blank = 1, _1Shield = 2, _2Shield = 3 };
 */
    public Dice()
    {
        valMin = 1;
        valMax = 6;
    }

    /*
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
    */

    public bool GetHit()
    {
        RollBlueDie();
        return miss;
    }
    public bool GetSurge()
    {
        return surge;
    }
    public int GetRange()
    {
        return range;
    }
    public int GetDamage()
    {
        return damage;
    }

    void RollBlueDie()
    {

        int diceRoll;
        diceRoll = RollDice();

        switch (diceRoll)
        {
            case 1:
                miss = true;
                break;
            case 2:
                range = 2; damage = 2; surge = true;
                break;
            case 3:
                range = 3; damage = 2;
                break;
            case 4:
                range = 4; damage = 2;
                break;
            case 5:
                range = 5; damage = 1;
                break;
            case 6:
                range = 6; damage = 1; surge = true;
                break;
            default:
                range = 3; damage = 2;
                break;
        }

        // work out how to return the data
    }

    public int RollDefenceDie(int dieCase)                //standard defence die - 
    {
        int defenceVal, lowLimit, highLimit, common;

        if (dieCase == 0)                   // grey die
        {
            lowLimit = 0;
            highLimit = 2;
            common = 1;
        }
        else if (dieCase == 1)              //brown die
        {
            lowLimit = 0;
            highLimit = 3;
            common = 0;
        }
        else                                    //black die
        {
            lowLimit = 1;
            highLimit = 4;
            common = 2;
        }

        defenceVal = RollDice();

        switch (defenceVal)
        {
            case 1:
                defenceVal = lowLimit;
                break;
            case 2:
                defenceVal = lowLimit + 1;
                break;
            case 3:
                defenceVal = highLimit - 1;
                break;
            case 4:
                defenceVal = highLimit;
                break;
            default:
                defenceVal = common;
                break;
        }

        return defenceVal;
    }

    int RollDice()
    {
        return Random.Range(valMin, valMax);
    }
}
