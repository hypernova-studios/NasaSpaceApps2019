using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Deck of cards for our game
/// </summary>
public class Deck
{
    private List<Card> deck = new List<Card>();

    /// <summary>
    /// Initialize a new deck (currently does nothing. Deck will be empty)
    /// </summary>
    public Deck()
    {

    }

    /// <summary>
    /// Add a card to the deck
    /// </summary>
    /// <param name="card">The card to add</param>
    public void AddCard(Card card)
    {
        deck.Add(card);
        return;
    }

    /// <summary>
    /// Shuffles the Deck of Cards
    /// </summary>
    public void Shuffle()
    {
        List<Card> tempDeck = deck;
        deck.Clear();

        while(tempDeck.Count > 0)
        {
            int card = HSRandom.Next(tempDeck.Count);
            deck.Add(tempDeck[card]);
            tempDeck.RemoveAt(card);
        }
        return;
    }

    /// <summary>
    /// Draws a card off of the top of the deck (element 0). This also removes the
    /// card from the deck
    /// </summary>
    /// <returns>The card on top of the deck.</returns>
    public Card DrawCard()
    {
        Card card = deck[0];
        deck.RemoveAt(0);
        return card;
    }
}
