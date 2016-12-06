using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float xVal = 15.1f;
    float yVal = 15.075f;
    //delegate int Actiononi(int val);
    //Actiononi setActionse = new Actiononi(Actionse);
    //bool complete = false;
    int move = 0, playerTurnNumber, thisPlayerNo;
    public GameObject players;
    public Hero hero;

    public PlayerMovement(GameObject temp1, Hero temp2, int temp3)
    {
        players = temp1;
        hero = temp2;
        thisPlayerNo = temp3;
    }

    /*
    void Update()
    {
        playerTurnNumber = GetComponentInParent<Game>().GetPlayerTurnNo();
        if (move > 0 && playerTurnNumber == thisPlayerNo)
        {
            CharacterMovement();
        }
        if (move <= 0)
        {
            hero.UnsetActions();
        }
    }   */


    public void MovementSelected(int moveTemp)
    {
        move = moveTemp;
        while (move > 0)
        {
            if (playerTurnNumber == thisPlayerNo)
            {
                CharacterMovement();
            }
        }
    }

    void CharacterMovement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            players.gameObject.transform.Translate(0, 0, -yVal);
            move--;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            players.gameObject.transform.Translate(-xVal, 0, -yVal);
            move--;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            players.gameObject.transform.Translate(-xVal, 0, 0);
            move--;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            players.gameObject.transform.Translate(-xVal, 0, yVal);
            move--;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            players.gameObject.transform.Translate(0, 0, yVal);
            move--;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            players.gameObject.transform.Translate(xVal, 0, yVal);
            move--;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            players.gameObject.transform.Translate(xVal, 0, 0);
            move--;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            players.gameObject.transform.Translate(xVal, 0, -yVal);
            move--;
        }
    }
}



