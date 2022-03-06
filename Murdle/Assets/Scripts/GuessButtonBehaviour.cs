using System;
using UnityEngine;

public class GuessButtonBehaviour : MonoBehaviour
{
    public WeaponSlot weaponSlot;
    public MotivationSlot motivationSlot;
    public SuspectSlot suspectSlot;

    public WorldManager worldManager;

    public void OnButtonPress()
    {
        Debug.Log("Guess Button Pressed!");
        
        // -- Get Each Object in Item Slots -- //
        // Weapon guessWeapon = GameObject.Find("Canvas/WeaponSlot").GetComponent<WeaponSlot>().weapon;
        // Motivation guessMotivation = GameObject.Find("Canvas/MotivationSlot").GetComponent<MotivationSlot>().motivation;
        // Suspect guessSuspect = GameObject.Find("Canvas/SuspectSlot").GetComponent<SuspectSlot>().suspect;

        Weapon guessWeapon = weaponSlot.weapon;
        Motivation guessMotivation = motivationSlot.motivation;
        Suspect guessSuspect = suspectSlot.suspect;

        // -- Perform Validations on Item Slots -- //
        if (guessWeapon == null || guessMotivation == null || guessSuspect == null) return;
        
        // -- Check if Guess

        // -- Get Scenario Object from WorldManager -- //
        Scenario scenario = worldManager.scenario;

        // -- Get Distance Between each Item Slot and Scenario -- //
        double weaponDistance = guessWeapon.getDistance(scenario.correctWeapon) / Math.Sqrt(4*4*3);
        double motivationDistance = guessMotivation.getDistance(scenario.correctMotivation) / 19;
        double suspectDistance = guessSuspect.getDistance(scenario.correctSuspect) / Math.Sqrt(4*4*3);

        // -- Update Item Slot Colours -- //
        Color weaponColour = getColourFromDistance(weaponDistance);
        Color motivationColour = getColourFromDistance(motivationDistance);
        Color suspectColour = getColourFromDistance(suspectDistance);
        
        // TODO change slots' colours
    }

    private Color getColourFromDistance(double value)
    {
        value = Math.Min(Math.Max(0,value), 1) * 510;

        double redValue;
        double greenValue;
        
        if (value < 255) {
            redValue = 255;
            greenValue = Math.Sqrt(value) * 16;
            greenValue = Math.Round(greenValue);
        } else {
            greenValue = 255;
            value = value - 255;
            redValue = 256 - (value * value / 255);
            redValue = Math.Round(redValue);
        }
        
        return new Color((float) redValue, (float) greenValue, 0, 1);
    }
    
}