using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public abstract class Actions : MonoBehaviour
{
    //make the class an abstract class so that you cannot create an instance of this without it being on a child
    Dice theDie = new Dice();
    Vector3 move;
    int addionalDie, actionse = 0;
    float xVal, yVal;
    bool actions = false;


    public abstract void Damaged(int damage);

    public void Attack()  // send the minion being attacked
    {
        bool didHit, surge, extra;                          // , ranged;
        int range, damage, die = 0, defence = 0, temp = 0;
        //get dice
        // send 0 for no additional dice, 1 yellow, 2 red
        //die = this.additional
        didHit = theDie.GetHit(die);
        //temp = Minion.GetDefence();

        if (didHit == true)
        {
            //do the rest
            range = theDie.GetRange();
            surge = theDie.GetSurge();
            extra = theDie.ExtraSurge();
            damage = theDie.GetDamage();
            //get defence die
            Debug.Log("Available Range: " + range + " Damage: " + damage + " Surge: " + surge + " & " + extra);

            defence = theDie.RollDefenceDie(temp);
            damage -= defence;
            //minion.damaged();
            if (damage <= 0)
            {
                //damage blocked
            }
        }
    }

    void Start()
    {
        xVal = 15.1f;
        yVal = 15.075f;
    }

    public void SetActions()
    {
        actions = true;
        actionse++;
    }

    void Update()
    {
        //  float temp = GetMovement();
        if (actions && (actionse > 0))
        {
            // Move(temp);
            CharacterMovement();
        }
    }


    void CharacterMovement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.gameObject.transform.Translate(0, 0, -yVal);
            actionse--;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.gameObject.transform.Translate(-xVal, 0, -yVal);
            actionse--;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.gameObject.gameObject.transform.Translate(-xVal, 0, 0);
            actionse--;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            this.gameObject.gameObject.transform.Translate(-xVal, 0, yVal);
            actionse--;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            this.gameObject.gameObject.transform.Translate(0, 0, yVal);
            actionse--;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            this.gameObject.gameObject.transform.Translate(xVal, 0, yVal);
            actionse--;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            this.gameObject.gameObject.transform.Translate(xVal, 0, 0);
            actionse--;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.gameObject.gameObject.transform.Translate(xVal, 0, -yVal);
            actionse--;
        }
        if (actionse == 0)
        {
            actions = false;
        }

    }

    /*
    float GetMovement()
    {
        float x, y, done = 0;
        //Debug.Log("Waiting for button press ");
        // CheckButtonPress();
        if (Input.GetKey("d") || Input.GetKey("e") || Input.GetKey("c"))            //see if the character is moving in a certain direction
        {
            x = xVal;                                                                   //set the variable to the preset distance.     
            done = (x * 10);                                                                           //set the variable to break the loop
        }
        if (Input.GetKey("a") || Input.GetKey("q") || Input.GetKey("z"))
        {
            x = -xVal;
            done = (x * 10);
        }
        if (Input.GetKey("w") || Input.GetKey("e") || Input.GetKey("q"))
        {
            y = yVal;
            done += y;
        }

        if (Input.GetKey("x") || Input.GetKey("c") || Input.GetKey("z"))
        {
            y = -yVal;
            done += y;
        }

        if (done != 0)
        {
            Debug.Log("BUTTON PRESSED FINALLY");
            return done;
        }
        else return 0;
    }
    void Move(float done)
    {
        //allow movement upto max movements spaces or additional with fatigue
        Debug.Log("I GONNA MOVE");
        int x, y;
        y = (Convert.ToInt32(done)) % 10;
        done /= 10;
        x = Convert.ToInt32(done);

        Vector3 temp = new Vector3(x, y, 0);                        //Get direction values
        this.gameObject.transform.Translate(temp);                  //move the gameObject that far
        x = 0;                                                      //reset the movement variables
        y = 0;
    }
    */

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
