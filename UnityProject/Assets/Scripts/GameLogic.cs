using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Determines the winner for a set of 2 cards
    /// </summary>
    /// <param name="card0">The Card of the user</param>
    /// <param name="card1">The Card of the computer</param>
    /// <returns>
    /// Zero if the player wins and One if the computer wins. In the case that
    /// there is an error with this function in parsing, it returns 2.
    /// </returns>
    int DetermineWinner(Card card0, Card card1)
    {

        int population0, population1;

        if(!int.TryParse(card0.population, out population0))
        {
            return 2;
        }
        if(!int.TryParse(card1.population, out population1))
        {
            return 2;
        }

        if (population0 > population1)
        {
            return 0;
        } else
        {
            return 1;
        }
    }
}
