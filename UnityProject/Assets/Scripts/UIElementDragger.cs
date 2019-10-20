using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIElementDragger : EventTrigger {

    public bool dragging;

    public void Update() {
        if (dragging) {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y + 300);
        }
    }

    public override void OnPointerDown(PointerEventData eventData) {
        dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData) {
        dragging = false;
        transform.position = transform.parent.transform.position;
    }
}
