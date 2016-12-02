using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float xVal = 15.1f;
    float yVal = 15.075f;
    delegate int Actiononi(int val);
    Actiononi setActionse = new Actiononi(Actionse);

    [SerializeField]
    int playerTurnNumber;

    int playerNumber;

    GameObject playerObject;

    void Start()
    {
        Debug.Log(playerTurnNumber);
    }

    void Update()
    {
        playerNumber = GameObject.Find("Board").GetComponent<Game>().GetPlayerTurnNo();
    }

    public void MovementSelected()
    {
        if (playerTurnNumber == 0)
        {
            playerNumber = 0;
            playerObject = GameObject.Find("Player1");
            setActionse += GameObject.Find("Player1").GetComponent<Hero>().Actionse;
            CharacterMovement();
        }
        if (playerTurnNumber == 1)
        {
            playerNumber = 1;
            playerObject = GameObject.Find("Player2");
            setActionse += GameObject.Find("Player2").GetComponent<Hero>().Actionse;
            CharacterMovement();
        }
        if (playerTurnNumber == 2)
        {
            playerNumber = 2;
            playerObject = GameObject.Find("Player3");
            setActionse += GameObject.Find("Player3").GetComponent<Hero>().Actionse;
            CharacterMovement();
        }
        if (playerTurnNumber == 3)
        {
            playerNumber = 3;
            playerObject = GameObject.Find("Player4");
            setActionse += GameObject.Find("Player4").GetComponent<Hero>().Actionse;
            CharacterMovement();
        }
    }

    void CharacterMovement()
    {
        int temp = 1;
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerObject.transform.Translate(0, 0, -yVal);
            setActionse(temp);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerObject.transform.Translate(-xVal, 0, -yVal);
            setActionse(temp);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerObject.gameObject.transform.Translate(-xVal, 0, 0);
            setActionse(temp);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerObject.gameObject.transform.Translate(-xVal, 0, yVal);
            setActionse(temp);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            playerObject.gameObject.transform.Translate(0, 0, yVal);
            setActionse(temp);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerObject.gameObject.transform.Translate(xVal, 0, yVal);
            setActionse(temp);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerObject.gameObject.transform.Translate(xVal, 0, 0);
            setActionse(temp);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerObject.gameObject.transform.Translate(xVal, 0, -yVal);
            setActionse(temp);
        }
    }
}



