using UnityEngine;
using System.Collections;

public class Actions : MonoBehaviour
{
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
        xVal = 1.06f;
        yVal = 1.07f;
    }

    void GetMovement()
    {
        bool buttonPressed = false;

        while (buttonPressed == false)
        {
            Debug.Log("Waiting for button press");
            if (Input.GetKey("d") || Input.GetKey("e") || Input.GetKey("c"))
            {
                x = xVal;
                buttonPressed = true;
            }
            if (Input.GetKey("w") || Input.GetKey("e") || Input.GetKey("q"))
            {
                y = yVal;
                buttonPressed = true;
            }
            if (Input.GetKey("a") || Input.GetKey("q") || Input.GetKey("z"))
            {
                x = -xVal;
                buttonPressed = true;
            }
            if (Input.GetKey("x") || Input.GetKey("c") || Input.GetKey("z"))
            {
                y = -yVal;
                buttonPressed = true;
            }
        }
    }

    public void Move(int moveLimit)
    {
        //allow movement upto max movements spaces or additional with fatigue
        int tempMove = 0;
        Debug.Log("Moving " + moveLimit);

        while (tempMove < moveLimit)
        {
            GetMovement();
            move = new Vector3(x, y, 0);
            this.gameObject.transform.Translate(move);
            x = 0;
            y = 0;
            tempMove++;
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

    protected void Special()
    {

    }
}
