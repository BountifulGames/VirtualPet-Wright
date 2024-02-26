using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//////////////////////////////////////////////
//Assignment/Lab/Project: Vitual Pet
//Name: Hunter Wright
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 2/26/2024
/////////////////////////////////////////////
public class Pet //Pet class with the variables for name, hunger, happiness, and energy. Can be called by the PetController
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

    //Getters and setters for the values of the pet object, makes sure to clamp values between 0 and 100
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
