using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class WorldManager : MonoBehaviour {
    public GameObject weaponPrefab;
    public GameObject suspectPrefab;
    public GameObject motivationPrefab;
    public Transform sceneTransform;
    public RectTransform sceneRect;

    public Scenario scenario;

    public int numWeapons = 20;
    public int numSuspects = 0;
    public int numMotivations = 5;

    private const string CSVBasePath = "Assets/images_and_stuff/"; 
    private const string SpriteBasePath = "Assets/Sprites/"; 
    
    private void Start() {
        scenario = GenerateScenario();
        
        // TODO select a winning 3-tuple from scenario. So, a (weapon, suspect, motivation) which is the correct answer
        
        Random rnd = new Random();
        
        foreach (var weapon in scenario.weapons) {
            GameObject obj = Instantiate(weaponPrefab, sceneRect);
            obj.transform.localPosition = new Vector3(rnd.Next(1, (int) sceneRect.rect.width), rnd.Next(1, (int) sceneRect.rect.height), 0f);
            
            Weapon weaponScript = obj.GetComponent<Weapon>();
            
            weaponScript.Copy(weapon);
            obj.GetComponent<RawImage>().texture = getImg(SpriteBasePath + weaponScript.imageName);
        }
        
        foreach (var suspect in scenario.suspects) {
            GameObject obj = Instantiate(suspectPrefab, sceneRect);
            obj.transform.localPosition = new Vector3(rnd.Next(1, (int) sceneRect.rect.width), rnd.Next(1, (int) sceneRect.rect.height), 0f);
            
            Suspect suspectScript = obj.GetComponent<Suspect>();
            suspectScript.Copy(suspect);
            obj.GetComponent<RawImage>().texture = getImg(SpriteBasePath + suspectScript.imageName);
        }

        foreach (var motivation in scenario.motivations) {
            GameObject obj = Instantiate(motivationPrefab, sceneTransform);
            obj.transform.localPosition = new Vector3(rnd.Next(1, (int) sceneRect.rect.width), rnd.Next(1, (int) sceneRect.rect.height), 0f);

            Motivation motivationScript = obj.GetComponent<Motivation>();
            motivationScript.Copy(motivation);
            obj.GetComponent<RawImage>().texture = getImg("Assets/images_and_stuff/evidence_png/002-analysis.png");
        }
    }

    private Scenario GenerateScenario() {
        string weaponsFile = CSVBasePath + "weapon_attributes.csv";
        string suspectsFile = CSVBasePath + "suspect_attributes.csv";
        string motivationsFile = CSVBasePath + "motivations_messages.csv";
    
        // -- Get List of All Possible Scenario Objects -- //
        List<Weapon> allWeapons = Utility.getWeaponsFromCSV(weaponsFile);
        List<Suspect> allSuspects = Utility.getSuspectsFromCSV(suspectsFile);
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
        
        return new Scenario(weaponList, suspectList, motivationList,
                            weaponList[0], suspectList[0], motivationList[0]);
    }

    private Texture2D getImg(string path) {
        // read image and store in a byte array
        byte[] byteArray = File.ReadAllBytes(path);
        
        //create a texture and load byte array to it
        Texture2D sampleTexture = new Texture2D(2,2);
        
        // the size of the texture will be replaced by image size
        bool isLoaded = sampleTexture.LoadImage(byteArray);
        
        return isLoaded ? sampleTexture : null;
    }
}
