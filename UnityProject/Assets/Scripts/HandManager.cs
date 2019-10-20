using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public Player player;
    public GameObject cardLayout;

    private Deck deck;
    public GameObject[] spawns;

    // Start is called before the first frame update
    void Start()
    {
        deck = new Deck("Assets/Resources/basic.deck");
        
        deck.Shuffle();
        for(int i=0; i < 5; i++)
        {
            var card = deck.DrawCard();
            var c = Instantiate(cardLayout, spawns[i].transform);
            c.GetComponent<CardDisplay>().card = card;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
