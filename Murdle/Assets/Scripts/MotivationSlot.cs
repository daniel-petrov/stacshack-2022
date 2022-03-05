using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MotivationSlot : MonoBehaviour, IDropHandler
{
    public RectTransform localRectTransform;
    public Motivation motivation;

    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            // -- Do Checks -- //
            Motivation draggedMotivation = eventData.pointerDrag.GetComponent<Motivation>();

            if (draggedMotivation == null) return;
            
            // -- Update Item Slot -- //
            motivation = draggedMotivation;
            
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;
        }
    }
}