using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Motivation : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    
    /* -- Attributes -- */
    public string imageName;
    public double scale;
    public string emotion;
    public string message;

    /* -- Default Contructor -- */
    public Motivation(string imageName, double scale, string emotion, string message)
    {
        this.imageName = imageName;
        this.scale = scale;
        this.emotion = emotion;
        this.message = message;
    }
    
    public void Copy(Motivation motivation)
    {
        this.imageName = motivation.imageName;
        this.scale = motivation.scale;
        this.emotion = motivation.emotion;
        this.message = motivation.message;
    }
    
    /*
     * Calculate Euclidean Distance between the attributes of this motivation, and another motivation.
     */
    public double getDistance(Motivation motiv)
    {
        return Math.Abs(this.scale - motiv.scale);
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