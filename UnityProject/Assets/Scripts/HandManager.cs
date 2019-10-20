using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public Player player;
    public GameObject cardLayout;

    private Deck deck;
    public GameObject[] spawns;

    private bool isTurn=true;

    // Start is called before the first frame update
    void Start()
    {
        deck = player.deck;
        
        deck.Shuffle();
        for(int i=0; i < 5; i++)
        {
            var card = deck.DrawCard();
            var c = Instantiate(cardLayout, spawns[i].transform);
            c.GetComponent<CardDisplay>().card = card;
        }
    }

    public void endTurn(GameObject caller)
    {
        var x = GetComponentsInChildren<UIElementDragger>();
        foreach(var i in x)
        {
            i.enabled = false;
        }
        if(isTurn)
        {
            var enemyCard = GameObject.Find("EnemyHandManager").GetComponentInChildren<EnemyHM>().playCard();
            isTurn=false;
            if(!GameLogic.GetInstance().EndRound(caller.GetComponentInChildren<CardDisplay>().card, enemyCard))
            {

                Destroy(caller, 5);
                Destroy(enemyCard);
            }
        }
    }

    public void beginTurn()
    {
        var x = GetComponentsInChildren<UIElementDragger>();
        foreach(var i in x)
        {
            i.enabled = true;
        }
    }
}
