using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    private GameState currentGameState;
    int playerTurn = 1;

    public enum GameState
    {
        preGame,
        player1Turn,
        player2Turn,
        player3Turn,
        player4Turn,
        overlordTurn,
        endgame
    }

    void Start()
    {
        currentGameState = GameState.preGame;
    }

    void Update()
    {
        if (currentGameState == GameState.player1Turn)
        {
            if (playerTurn < 3)
            {
                playerTurn++;
            }
            else
            {
                playerTurn = 1;
                currentGameState = GameState.overlordTurn;
            }
        }
    }

    void PlayerTurn(int player)
    {

    }
}
