using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTextScript : MonoBehaviour
{
    public void Win()
    {
        var x = GetComponent<Text>();
        x.text = "YOU WIN!\n[esc] to exit";
    }

    public void Lose()
    {
        var x = GetComponent<Text>();
        x.text = "YOU LOSE!\n[esc] to exit";
    }
}
