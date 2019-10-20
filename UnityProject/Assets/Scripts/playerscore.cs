using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerscore : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponentInChildren<Text>().text = GameLogic.GetInstance().player0.GetRoundsWon().ToString();
    }
}
