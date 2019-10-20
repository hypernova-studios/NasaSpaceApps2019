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
    public bool dragging;
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

    void Update()
    {
        dragging = GetComponent<Transform>().GetComponentInChildren<UIElementDragger>().dragging;
        if(!dragging)
        {
            transform.localScale = new Vector3(0.33f, 0.33f, 0.33f);
        } else {
            transform.localScale = new Vector3(1f, 1f, 1f);
            transform.SetAsLastSibling();
        }
    }
}
