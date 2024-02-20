using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet
{
    public string name;
    public int hunger;
    public int happiness;
    public int energy;

    public void Feed()
    {
        Hunger -= 20;
        Happiness += 5;
    }

    public void Rest()
    {
        Energy += 20;
        Happiness += 5;
    }

    public void Play()
    {
        Happiness += 20;
        Hunger += 10;
        Energy -= 10;
    }

    //Getters and setters for the values of the pet object
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Hunger
    {
        get { return hunger; }
        set { hunger = Mathf.Clamp(value, 0, 100); }
    }

    public int Happiness
    {
        get { return happiness; }
        set { happiness = Mathf.Clamp(value, 0, 100); }
    }

    public int Energy
    {
        get { return energy; }
        set { energy = Mathf.Clamp(value, 0, 100); }
    }

    public Pet(string name) //Initialize pet object with base values and the name provided
    {
        Name = name;
        Hunger = 0;
        Happiness = 100;
        Energy = 100;
    }

}
