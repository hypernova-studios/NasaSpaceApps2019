using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    private Text descField;
    private Text popField;
    private Image imageField;

    public bool inHand;
    private Transform t;

    // Start is called before the first frame update
    void Start()
    {
        inHand = true;
        descField = GetComponent<Transform>().Find("descField").GetComponent<Text>();
        popField = GetComponent<Transform>().Find("popField").GetComponent<Text>();
        imageField = GetComponent<Transform>().Find("imageField").GetComponent<Image>();

        descField.text = card.text;
        popField.text = card.population;
        imageField.sprite = card.artwork;
    }
}
