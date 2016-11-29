using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    float xVal = 15.1f;
    float yVal = 15.075f;

    [SerializeField]
    int playerTurnNumber;

    int playerNumber;

    GameObject playerObject;

    void Start()
    {
        playerTurnNumber = 0;                //GameObject.Find("Board").GetComponent<Game>().playerTurnNo;
        Debug.Log(playerTurnNumber);
    }

    void Update()
    {

    }

    public void MovementSelected()
    {
        if (playerTurnNumber == 0)
        {
            playerNumber = 0;
            playerObject = GameObject.Find("Player1");
            CharacterMovement();
        }
        if (playerTurnNumber == 1)
        {
            playerNumber = 1;
            playerObject = GameObject.Find("Player2");
            CharacterMovement();
        }
        if (playerTurnNumber == 2)
        {
            playerNumber = 2;
            playerObject = GameObject.Find("Player3");
            CharacterMovement();
        }
        if (playerTurnNumber == 3)
        {
            playerNumber = 3;
            playerObject = GameObject.Find("Player4");
            CharacterMovement();
        }
    }

    void CharacterMovement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerObject.transform.Translate(0, 0, -yVal);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerObject.transform.Translate(-xVal, 0, -yVal);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerObject.gameObject.transform.Translate(-xVal, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerObject.gameObject.transform.Translate(-xVal, 0, yVal);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            playerObject.gameObject.transform.Translate(0, 0, yVal);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerObject.gameObject.transform.Translate(xVal, 0, yVal);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerObject.gameObject.transform.Translate(xVal, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerObject.gameObject.transform.Translate(xVal, 0, -yVal);
        }

    }
}



