using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    /* -- Weapon Attributes -- */
    public string imageName;
    public double effectiveness;
    public double mass;
    public double activeness;
    public double sharpness;

    /* -- Default Constructor -- */
    public Weapon(string imageName, double effectiveness, double mass, double activeness, double sharpness)
    {
        this.imageName = imageName;
        this.effectiveness = effectiveness;
        this.activeness = activeness;
        this.sharpness = sharpness;
        this.mass = mass;
    }
    
    public void Copy(Weapon weapon) {
        imageName = weapon.imageName;
        effectiveness = weapon.effectiveness;
        activeness = weapon.activeness;
        sharpness = weapon.sharpness;
        mass = weapon.mass;
    }

    /*
     * Calculate Euclidean Distance between the attributes of this weapon, and another weapon.
     */
    public double getDistance(Weapon weapon)
    {
        double distance = 0;

        distance += Math.Pow(this.effectiveness - weapon.effectiveness, 2);
        distance += Math.Pow(this.activeness - weapon.activeness, 2);
        distance += Math.Pow(this.sharpness - weapon.sharpness, 2);
        distance += Math.Pow(this.mass - weapon.mass, 2);

        return Math.Sqrt(distance);

    }

    /* -- Unity Shtuff -- */
    private Canvas canvas;
    
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}