using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MouseOverAttack : MonoBehaviour
{
    int playerTurn;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Collider>();
    }

    void OnMouseEnter()
    {
        playerTurn = Game.GetPlayerTurnNo();
        players[playerTurn].Attack();
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectWithTag("goblin"))
        {
            OnMouseEnter();
        }
    }
}
