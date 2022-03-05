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
    
    public void Copy(Motivation motivation) {
        // TODO copy all attributes from motivation to this object
    }
    
    /*
     * Calculate Euclidean Distance between the attributes of this motivation, and another motivation.
     */
    public double getDistance(Motivation motiv)
    {
        return Math.Abs(this.scale - motiv.scale);
    }

}