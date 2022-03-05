using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SuspectSlot : MonoBehaviour, IDropHandler
{
    public RectTransform localRectTransform;
    public Suspect suspect;

    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            // -- Do Checks -- //
            Suspect draggedSuspect = eventData.pointerDrag.GetComponent<Suspect>();

            if (draggedSuspect == null) return;
            
            // -- Update Item Slot -- //
            suspect = draggedSuspect;
            
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;
        }
    }
}