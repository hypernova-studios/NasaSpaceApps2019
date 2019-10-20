using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int roundsWon;
    private int roundsLost;
    public Deck deck = null;


    public Player()
    {
        roundsWon = 0;
        roundsLost = 0;
        //deck = MasterDeck.GetRandomDeck();
    }

    public void Awake() {
        if(deck == null) {deck = MasterDeck.GetRandomDeck();}
    }

    public Player(Deck deck)
    {
        roundsWon = 0;
        roundsLost = 0;
        this.deck = deck;
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
