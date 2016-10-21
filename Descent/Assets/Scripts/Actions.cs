using UnityEngine;
using System.Collections;

public class Actions
{
    Dice theDie = new Dice();

    protected void Attack()
    {
        bool didHit, surge;
        int range, damage;
        didHit = theDie.GetHit();

        if(didHit == true)
        {
            //do the rest 
            range = theDie.GetRange();
            surge = theDie.GetSurge();
            damage = theDie.GetDamage();
        }else
        {
            //you missed failure
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
