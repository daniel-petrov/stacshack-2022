using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

public class WorldManager : MonoBehaviour {
    public GameObject weapon;
    public Transform sceneTransform;
    
    private void Start() {
        Random rnd = new Random();
        for (int i = 0; i < 15; i++) {
            GameObject obj = Instantiate(weapon, new Vector3(rnd.Next(1,10) * 1f, rnd.Next(1,10) * 1f, 0f), new Quaternion(), sceneTransform);
            
            Test weaponScript = obj.GetComponent<Test>();
            weaponScript.a = obj.transform.position.x;
            weaponScript.b = obj.transform.position.y;
            weaponScript.outputStats();
        }
        
    }
}
