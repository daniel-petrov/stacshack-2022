﻿using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
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

    /*
     * Calculate Euclidean Distance between the attributes of this weapon, and another weapon.
     */
    double getDistance(Weapon weapon)
    {
        double distance = 0;

        distance += Math.Pow(this.effectiveness - weapon.effectiveness, 2);
        distance += Math.Pow(this.activeness - weapon.activeness, 2);
        distance += Math.Pow(this.sharpness - weapon.sharpness, 2);
        distance += Math.Pow(this.mass - weapon.mass, 2);

        return Math.Sqrt(distance);

    }
    
    /* -- Unity Methods -- */
    
    
}