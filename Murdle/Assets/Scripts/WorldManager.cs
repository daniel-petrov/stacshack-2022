using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

public class WorldManager : MonoBehaviour {
    public GameObject weaponPrefab;
    public GameObject suspectPrefab;
    public GameObject motivationPrefab;
    public Transform sceneTransform;

    public int numWeapons = 20;
    public int numSuspects = 0;
    public int numMotivations = 5;

    private const string BasePath = "assets/images_and_stuff/"; 
    
    private void Start() {
        Scenario scenario = GenerateScenario();
        
        // TODO select a winning 3-tuple from scenario. So, a (weapon, suspect, motivation) which is the correct answer
        
        Random rnd = new Random();
        
        foreach (var weapon in scenario.weapons) {
            GameObject obj = Instantiate(weaponPrefab, new Vector3(rnd.Next(1,10) * 1f, rnd.Next(1,10) * 1f, 0f), new Quaternion(), sceneTransform);
            
            Weapon weaponScript = obj.GetComponent<Weapon>();
            weaponScript.Copy(weapon);
        }
        
        foreach (var suspect in scenario.suspects) {
            GameObject obj = Instantiate(suspectPrefab, new Vector3(rnd.Next(1,10) * 1f, rnd.Next(1,10) * 1f, 0f), new Quaternion(), sceneTransform);
            
            Suspect suspectScript = obj.GetComponent<Suspect>();
            suspectScript.Copy(suspect);
        }

        foreach (var motivation in scenario.motivations) {
            GameObject obj = Instantiate(motivationPrefab, new Vector3(rnd.Next(1, 10) * 1f, rnd.Next(1, 10) * 1f, 0f),
                new Quaternion(), sceneTransform);

            Motivation motivationScript = obj.GetComponent<Motivation>();
            motivationScript.Copy(motivation);
        }
    }

    private Scenario GenerateScenario() {
        string weaponsFile = BasePath + "weapon_attributes.csv";
        string suspectsFile = "suspect_attributes.csv";
        string motivationsFile = BasePath + "motivations_messages.csv";
    
        // -- Get List of All Possible Scenario Objects -- //
        List<Weapon> allWeapons = Utility.getWeaponsFromCSV(weaponsFile);
        List<Suspect> allSuspects = new List<Suspect>();
        List<Motivation> allMotivations = Utility.getMotivationsFromCSV(motivationsFile);
        
        // -- Get Subset of All Scenario Objects -- //
        List<Weapon> weaponList = new List<Weapon>();
        List<Suspect> suspectList = new List<Suspect>();
        List<Motivation> motivationList = new List<Motivation>();
        
        // Add random numbers from 0 to list.Count to a indexSet
        // Add these indexes to the sublists

        // Set to keep track of random indexes chosen
        HashSet<int> indexSet = new HashSet<int>();

        Random rnd = new Random();

        // Keep picking random indexes until numWeapons number of [random indexes / weapons] have been chosen
        while (indexSet.Count < numWeapons) {
            int randomIndex = rnd.Next(0, allWeapons.Count);
            
            // If this index hasn't already been chosen then choose it and add it to the weapons list
            if (!indexSet.Contains(randomIndex)) {
                indexSet.Add(randomIndex);
                weaponList.Add(allWeapons[randomIndex]);
            }
        }
        
        // Reset the index set
        indexSet = new HashSet<int>();
        
        // Keep picking random indexes until numSuspects number of [random indexes / suspects] have been chosen
        while (indexSet.Count < numSuspects) {
            int randomIndex = rnd.Next(0, allSuspects.Count);
            
            // If this index hasn't already been chosen then choose it and add it to the suspects list
            if (!indexSet.Contains(randomIndex)) {
                indexSet.Add(randomIndex);
                suspectList.Add(allSuspects[randomIndex]);
            }
        }
        
        // Reset the index set
        indexSet = new HashSet<int>();
        
        // Keep picking random indexes until numMotivations number of [random indexes / motivations] have been chosen
        while (indexSet.Count < numMotivations) {
            int randomIndex = rnd.Next(0, allMotivations.Count);
            
            // If this index hasn't already been chosen then choose it and add it to the motivations list
            if (!indexSet.Contains(randomIndex)) {
                indexSet.Add(randomIndex);
                motivationList.Add(allMotivations[randomIndex]);
            }
        }
        
        return new Scenario(weaponList, suspectList, motivationList);
    }
    
}
