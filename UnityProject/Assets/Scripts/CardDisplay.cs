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

    // Start is called before the first frame update
    void Start()
    {
        card = JsonCardCreation.GetInstance().GetCard();

        descField = GetComponent<Transform>().Find("descField").GetComponent<Text>();
        popField = GetComponent<Transform>().Find("popField").GetComponent<Text>();
        imageField = GetComponent<Transform>().Find("imageField").GetComponent<Image>();

        descField.text = card.text;
        popField.text = card.population;
        imageField.sprite = card.artwork;

        //Debug.Log(JsonUtility.ToJson(card));
    }
}
