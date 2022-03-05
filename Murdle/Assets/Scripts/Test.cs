using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {
    public float a;
    public float b;

    public void outputStats() {
        Debug.Log("Weapon displaying it's values");
        Debug.Log(a);
        Debug.Log(b);
    }
}
