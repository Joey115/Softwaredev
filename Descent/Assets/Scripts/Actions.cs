using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public abstract class Actions : MonoBehaviour
{
    //make the class an abstract class so that you cannot create an instance of this without it being on a child
    Dice theDie = new Dice();
    Vector3 move;
    float x, y, xVal, yVal;

    public void Attack()
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
            if (damage <= 0)
            {
                //damage blocked
            }
        }
    }

    void Start()
    {
        xVal = 1.06f;                       //distance between squares
        yVal = 1.07f;
    }

    IEnumerator CheckButtonPress()
    {
        yield return new WaitForSeconds(3);
    }

    void GetMovement()
    {
        bool buttonPressed = false;                                                 //initialise the variable
        //stack overflow
        while (buttonPressed == false)                                                  //until there is a direction button moved implement
        {
            Debug.Log("Waiting for button press ");
            CheckButtonPress();
            if (Input.GetKey("d") || Input.GetKey("e") || Input.GetKey("c"))            //see if the character is moving in a certain direction
            {
                buttonPressed = true;
                x = xVal;                                                                   //set the variable to the preset distance.                                                                        //set the variable to break the loop
            }
            if (Input.GetKey("w") || Input.GetKey("e") || Input.GetKey("q"))
            {
                buttonPressed = true;
                y = yVal;
            }
            if (Input.GetKey("a") || Input.GetKey("q") || Input.GetKey("z"))
            {
                buttonPressed = true;
                x = -xVal;
            }
            if (Input.GetKey("x") || Input.GetKey("c") || Input.GetKey("z"))
            {
                buttonPressed = true;
                y = -yVal;
            }
        }
    }

    public void Move(int moveLimit)
    {
        //allow movement upto max movements spaces or additional with fatigue
        int amountMoved = 0;
        Vector3 temp;
        // Debug.Log("Moving " + moveLimit);
        while (amountMoved < moveLimit)                                //while the amount moved is less than the limit implement following
        {
            GetMovement();
            //Get direction values.
            temp = new Vector3(x, y, 0);
            this.gameObject.transform.Translate(temp);                  //move the gameObject that far
            x = 0;                                                      //reset the movement variables
            y = 0;
            amountMoved++;                                              //increment the amount moved variable
        }
    }

    protected void Rest()
    {
        //reset fatigue to 0
    }

    protected void Skill()
    {

    }

    protected void Search()
    {
        // gain a random item from the database search items
    }

    protected void StandUp()
    {
        //player can move

    }

    protected void Revive()
    {
        //target champion regains health
    }

    public abstract void Special(); // this means anything using this script will have to have it's own class version of it.
}
