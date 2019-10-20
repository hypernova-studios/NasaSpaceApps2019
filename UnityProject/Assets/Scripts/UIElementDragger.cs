using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIElementDragger : EventTrigger {

    public bool dragging;

    public void Update() {
        if (dragging) {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public override void OnPointerDown(PointerEventData eventData) {
        dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData) {
        dragging = false;
        if(transform.position.y > 750){
            transform.GetComponentInChildren<CardDisplay>().inHand = false;
            transform.GetComponentInChildren<CardDisplay>().onBoard = true;
            }
        if(transform.GetComponentInChildren<CardDisplay>().inHand){transform.position = transform.parent.transform.position;}
        else{transform.position = GameObject.Find("Player0PlayedCard").transform.position;}
    }
}
