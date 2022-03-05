using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlotScript : MonoBehaviour, IDropHandler {
    public RectTransform localRectTransform;

    public void OnDrop(PointerEventData eventData) {
        if (eventData != null) {
            
        }
    }
}
