using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Suspect : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    
    /* -- Suspect Attributes -- */
    public string imageName;
    public double eyeColour;
    public double hairColour;
    public double skinTan;

    /* -- Default Constructor -- */
    public Suspect(string imageName, double eyeColour, double hairColour, double skinTan)
    {
        this.imageName = imageName;
        this.eyeColour = eyeColour;
        this.hairColour = hairColour;
        this.skinTan = skinTan;
    }

    public void Copy(Suspect suspect)
    {
        this.imageName = suspect.imageName;
        this.eyeColour = suspect.eyeColour;
        this.hairColour = suspect.hairColour;
        this.skinTan = suspect.skinTan;
    }

    /*
     * Calculate Euclidean Distance between the attributes of this suspect, and another suspect.
     */
    public double getDistance(Suspect suspect)
    {
        double distance = 0.0;

        distance += Math.Pow(this.eyeColour - suspect.eyeColour, 2);
        distance += Math.Pow(this.hairColour - suspect.hairColour, 2);
        distance += Math.Pow(this.skinTan - suspect.skinTan, 2);

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