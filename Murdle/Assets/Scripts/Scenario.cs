using System;
using System.Collections.Generic;

public class Scenario
{
    public List<Weapon> weapons;
    public List<Suspect> suspects;
    public List<Motivation> motivations;

    public Weapon correctWeapon;
    public Suspect correctSuspect;
    public Motivation correctMotivation;

    public Scenario(List<Weapon> weapons, List<Suspect> suspects, List<Motivation> motivations,
                    Weapon correctWeapon, Suspect correctSuspect, Motivation correctMotivation)
    {
        this.weapons = weapons;
        this.suspects = suspects;
        this.motivations = motivations;
        this.correctWeapon = correctWeapon;
        this.correctSuspect = correctSuspect;
        this.correctMotivation = correctMotivation;
    }

}