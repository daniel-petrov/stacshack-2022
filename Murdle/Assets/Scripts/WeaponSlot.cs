using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponSlot : MonoBehaviour, IDropHandler
{
    public RectTransform localRectTransform;
    public Weapon weapon;

    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            // -- Do Checks -- //
            Weapon draggedWeapon = eventData.pointerDrag.GetComponent<Weapon>();

            if (draggedWeapon == null) return;
            
            // -- Update Item Slot -- //
            weapon = draggedWeapon;
            
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;
        }
    }
}