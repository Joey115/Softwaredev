using UnityEngine;
using System.Collections;

public class Actions : MonoBehaviour
{
    Dice theDie = new Dice();

    protected void Attack()
    {
        bool didHit, surge, extra;
        int range, damage, die = 0, defence = 0;
        //get dice
        // send 0 for no additional dice, 1 yellow, 2 red
        didHit = theDie.GetHit(die);

        if (didHit == true)
        {
            //do the rest
            range = theDie.GetRange();
            surge = theDie.GetSurge();
            extra = theDie.ExtraSurge();
            damage = theDie.GetDamage();
            //get defence die

            damage -= defence;
            if(damage<=0)
            {
                //damage blocked
            }
        }
        else
        {
            //you fail
        }

    }

    protected void Move()
    {

    }

    protected void Rest()
    {

    }

    protected void Skill()
    {

    }

    protected void Search()
    {

    }

    protected void StandUp()
    {

    }

    protected void Revive()
    {

    }

    protected void DoorInteract()
    {

    }

    protected void Special()
    {

    }
}
