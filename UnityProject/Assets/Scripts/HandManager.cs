using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HandManager : MonoBehaviour
{
    public Player player;
    public GameObject cardLayout;

    public Text endGameText;

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
            isTurn = false;
            caller.GetComponent<CardDisplay>().enabled = false;
            var enemyCard = GameObject.Find("EnemyHandManager").GetComponent<EnemyHM>().playCard();
            if(!GameObject.Find("GameRules").GetComponent<GameLogic>().EndRound(caller.GetComponent<CardDisplay>().card, enemyCard))
            {
                Destroy(caller, 5);
                Destroy(GameObject.Find("Player1PlayedCard").GetComponentInChildren<CardDisplay>().gameObject, 5);
                StartCoroutine(beginTurn());

                var card = deck.DrawCard();
                var c = Instantiate(cardLayout, caller.transform.parent);
                c.GetComponent<CardDisplay>().card = card;
            }
            else
            {
                if(GameObject.Find("GameRules").GetComponent<GameLogic>().GetWinner()==0)
                {
                    endGameText.GetComponent<EndTextScript>().Win();
                } else {
                    endGameText.GetComponent<EndTextScript>().Lose();
                }
            }
        }
    }

    IEnumerator beginTurn()
    {
        yield return new WaitForSeconds(5);
        var x = GetComponentsInChildren<UIElementDragger>();
        foreach(var i in x)
        {
            i.enabled = true;
        }
        isTurn = true;
    }
}
