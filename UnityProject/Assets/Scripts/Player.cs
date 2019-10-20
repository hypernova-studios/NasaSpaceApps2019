using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int roundsWon;
    private int roundsLost;
    public Deck deck;


    public Player()
    {
        roundsWon = 0;
        roundsLost = 0;
    }

    public void Awake() {
        deck = new Deck("Assets/Resources/basic.deck");
    }

    public void AddWin()
    {
        roundsWon++;
    }

    public void AddLoss()
    {
        roundsLost++;
    }

    public int GetRoundsWon()
    {
        return roundsWon;
    }

    public int GetRoundsLost()
    {
        return roundsLost;
    }
}
