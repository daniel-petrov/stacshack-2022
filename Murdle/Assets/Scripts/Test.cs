using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {
    public Image img;

    public Sprite spr1;
    public Sprite spr2;

    private int count = 1;
    public const int Max = 2;

    private void Start() {
        img.sprite = spr1;
    }

    private void Update() {
        count = count > 0 ? count + 1 : count - 1;
        if (count >= Max) {
            img.sprite = spr1;
            count = -1;
        } else if (count <= -1 * Max) {
            img.sprite = spr2;
            count = 1;
        }
    }
}
