using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Suspect : MonoBehaviour
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
}