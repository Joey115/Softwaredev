using UnityEngine;

public abstract class Actions : MonoBehaviour
{
    //make the class an abstract class so that you cannot create an instance of this without it being on a child
    Dice theDie = new Dice();
    int addionalDie, playerTurnNo, actionse = 0, move;
    float xVal, yVal;
    bool actions = false;
    public GameObject dave;
    protected PlayerMovement Move;


    public abstract void Damaged(int damage);

    public void Attack()  // send the minion being attacked
    {
        bool didHit, surge, extra;                          // , ranged;
        int range, damage, die = 0, defence = 0, temp = 0;
        // send 0 for no additional dice, 1 yellow, 2 red
        // die = this.additional();
        didHit = theDie.GetHit(die);
        //temp = bro.GetDefence();

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
            //bro.Damaged(damage);
            if (damage <= 0)
            {
                Debug.Log("DAMAGE blocked! " + damage);
            }
        }
    }

    void Start()
    {
        xVal = 60.4f;
        yVal = 60.3f;
    }

    public void SetActions(int moveTemp, int playerNo)
    {
        playerTurnNo = playerNo;
        actions = true;
        move = moveTemp;
    }
    void Update()
    {
        //  float temp = GetMovement();
        if (actions)
        {
            Move.MovementSelected(move, playerTurnNo);
            actions = false;
        }
    }

    /*
    void CharacterMovement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            dave.transform.Translate(0, 0, -yVal);
            actionse--;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            dave.transform.Translate(-xVal, 0, -yVal);
            actionse--;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            dave.gameObject.transform.Translate(-xVal, 0, 0);
            actionse--;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            dave.transform.Translate(-xVal, 0, yVal);
            actionse--;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            dave.transform.Translate(0, 0, yVal);
            actionse--;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            dave.transform.Translate(xVal, 0, yVal);
            actionse--;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dave.transform.Translate(xVal, 0, 0);
            actionse--;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            dave.transform.Translate(xVal, 0, -yVal);
            actionse--;
        }
        if (actionse == 0)
        {
            actions = false;
        }

    }

    
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
