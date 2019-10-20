using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterDeck : Deck
{
    private static MasterDeck instance = null;
    private static object padLock = new Object();

    private MasterDeck() : base("images")
    {

    }

    private static MasterDeck GetInstance()
    {
        if (instance == null)
        {
            lock (padLock)
            {
                if (instance == null)
                {
                    instance = new MasterDeck();
                    instance.Shuffle();
                }
            }
        }
        return instance;
    }

    /// <summary>
    /// Gets a random deck of cards from the master Deck. This will also remove
    /// those cards from the master deck. There is also a possibility that the
    /// master deck will run out of cards. In this case, this function will only
    /// return the remaining cards in the deck. This function also goes ahead and
    /// shuffles the cards before they are returned.
    /// </summary>
    /// <param name="size">The size of the deck to create. Defaults to 10.</param>
    /// <returns>A new Deck of cards.</returns>
    public static Deck GetRandomDeck(int size = 10)
    {
        lock (padLock)
        {
            MasterDeck master = MasterDeck.GetInstance();
            Deck newDeck = new Deck();

            while (newDeck.Size() < size && master.Size() > 0)
            {
                newDeck.AddCard(master.DrawCard());
            }

            newDeck.Shuffle();

            return newDeck;
        }
        
    }

    /// <summary>
    /// Resets the Master Deck to have all of the possible Cards again
    /// </summary>
    public static void Reset()
    {
        lock (padLock)
        {
            instance = new MasterDeck();
            instance.Shuffle();
        }
    }
}
