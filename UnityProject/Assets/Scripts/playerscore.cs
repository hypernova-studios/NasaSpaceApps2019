using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerscore : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GameObject.Find("PlayerScore").GetComponentInChildren<Text>().text = GameObject.Find("GameRules").GetComponent<GameLogic>().player0.GetRoundsWon().ToString();
    }
}
