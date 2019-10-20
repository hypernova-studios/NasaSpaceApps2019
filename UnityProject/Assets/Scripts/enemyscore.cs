using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyscore : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GameObject.Find("EnemyScore").GetComponentInChildren<Text>().text = GameObject.Find("GameRules").GetComponent<GameLogic>().player1.GetRoundsWon().ToString();
    }
}
