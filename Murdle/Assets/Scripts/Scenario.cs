using System;
using System.Collections.Generic;

public class Scenario
{
    public List<Weapon> weapons;
    public List<Suspect> suspects;
    public List<Motivation> motivations;

    public Scenario(List<Weapon> weapons, List<Suspect> suspects, List<Motivation> motivations)
    {
        this.weapons = weapons;
        this.suspects = suspects;
        this.motivations = motivations;
    }

}