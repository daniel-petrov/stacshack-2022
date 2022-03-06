using System;
using UnityEngine;

public class Motivation : MonoBehaviour {
    
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

}