using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    private static GameLogic instance;
    public Player player0; // The users Player
    public Player player1; // The Computers Player

    public static int numTotalRounds = 5;
    public int roundNum;


    // Start is called before the first frame update
    private GameLogic()
    {
        player0 = new Player();
        player1 = new Player();
        roundNum = 1;
    }

    public static GameLogic GetInstance()
    {
        if(instance == null)
        {
            instance = new GameLogic();
        }
        return instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Ends the current round
    /// </summary>
    /// <param name="card0">The Card played by the player</param>
    /// <param name="card1">The Card played by the Computer</param>
    /// <returns>
    /// If win conditions have been met. Ex) True means that a player has reached
    /// win conditions and False means that gameplay should continue into the next round
    /// </returns>
    public bool EndRound(Card card0, Card card1)
    {
        // Determine the winner of this turn
        int winner = DetermineHandWinner(card0, card1);
        Debug.Log("winner: " + winner.ToString());
        if(winner == 0)
        {
            player0.AddWin();
            player1.AddLoss();
        } else if (winner == 1)
        {
            player0.AddLoss();
            player1.AddWin();
        } else if (winner == 2)
        {
            
        }

        if (CheckWinConditions())
        {
            return true;
        }

        roundNum++;
        return false;
    }

    /// <summary>
    /// Determines the winner for a set of 2 cards
    /// </summary>
    /// <param name="card0">The Card of the user</param>
    /// <param name="card1">The Card of the computer</param>
    /// <returns>
    /// Zero if the player wins and One if the computer wins and two for a tie.
    /// In the case that there is an error with this function in parsing, it returns 3.
    /// </returns>
    int DetermineHandWinner(Card card0, Card card1)
    {

        int population0, population1;

        string card0Pop = card0.population;
        string card1Pop = card1.population;

        card0Pop = card0Pop.Replace(",", "");
        card1Pop = card1Pop.Replace(",", "");

        if(!int.TryParse(card0.population, out population0))
        {
            return 3;
        }
        if(!int.TryParse(card1.population, out population1))
        {
            return 3;
        }

        if (population0 > population1)
        {
            return 0;
        } else if (population1 > population0)
        {
            return 1;
        } else
        {
            return 2;
        }
    }

    /// <summary>
    /// Checks to see if anyone has reached the games win conditions.
    /// </summary>
    /// <returns>
    /// If win conditions have been met. Ex) True means that a player has reached
    /// win conditions and False means that gameplay should continue into the next round
    /// </returns>
    bool CheckWinConditions()
    {
        int minWins = numTotalRounds / 2;

        if(player0.GetRoundsWon() > minWins)
        {
            return true;
        } else if(player1.GetRoundsWon() > minWins)
        {
            return true;
            // TODO: Implement Ties after HandManager thing has been implemented.
        } else
        {
            return false;
        }
    }

    /// <summary>
    /// Gets the winner of the game as an int
    /// </summary>
    /// <returns>
    /// 0: The player (Player 1)
    /// 1: The Computer (or Player 2)
    /// 2: A tie between both
    /// </returns>
    int GetWinner()
    {
        if(player0.GetRoundsWon() > player1.GetRoundsWon())
        {
            return 0;
        } else if (player1.GetRoundsWon() > player0.GetRoundsWon())
        {
            return 1;
        } else
        {
            return 2;
        }
    }
}
