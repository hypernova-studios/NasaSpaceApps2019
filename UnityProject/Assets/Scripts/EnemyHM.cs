using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHM : MonoBehaviour
{
    public Player player;

    private Deck deck;

    public GameObject spawn;
    public GameObject cardLayout;

    // Start is called before the first frame update
    void Start()
    {
        deck = player.deck;

        Debug.Log(deck.Size());
        
        deck.Shuffle();

        Debug.Log(deck.Size());
    }

    public Card playCard() {
        var card = deck.DrawCard();
        var c = Instantiate(cardLayout, spawn.transform);
        c.GetComponent<CardDisplay>().card = card;
        c.GetComponent<CardDisplay>().inHand = false;
        c.GetComponent<CardDisplay>().onBoard = true;
        c.GetComponentInChildren<UIElementDragger>().enabled = false;
        c.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //GameObject.Find("HandManager").GetComponentInChildren<HandManager>().beginTurn();
        return card;
    }
}
