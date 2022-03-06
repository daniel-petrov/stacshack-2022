using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public static string Message;

    private void OnMouseEnter()
    {
        TooltipManager._instance.setAndShowTooltip(Message);
    }

    private void OnMouseExit()
    {
        TooltipManager._instance.HideTooltip();
    }
}
