using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////
//Assignment/Lab/Project: Vitual Pet
//Name: Hunter Wright
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 2/26/2024
/////////////////////////////////////////////

public class PetController : MonoBehaviour
{
    //All the object I need access to in the Inspector
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private GameObject submitButton;
    [SerializeField] private GameObject feedButton;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject restButton;
    [SerializeField] private GameObject newPetButton;
    [SerializeField] private GameObject submitBackground;
    [SerializeField] private GameObject petBackground;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private TMP_Text happinessText;
    [SerializeField] private TMP_Text hungerText;

    private Pet myPet;
    private float timeInterval = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SubmitButtonUpdate();
    }

    public void OnSubmitButtonPress() //Code that runs when you hit the submit button, such as changing background panels and creating a new Pet with the name provided 
    {
        submitBackground.SetActive(false);
        petBackground.SetActive(true);

        myPet = new Pet(nameInput.text.ToString());

        UpdateText();

        StartCoroutine(PassingTime());
    }
    //Code for running the various button presses, such as Feed, Rest, or Play
    public void OnFeedButtonPress()
    {
        myPet.Feed();
        UpdateText();
    }
    public void OnRestButtonPress()
    {
        myPet.Rest();
        UpdateText();
    }
    public void OnPlayButtonPress()
    {
        myPet.Play();
        UpdateText();
    }

    public void OnNewPetButtonPress() //If you fail, you can create a new pet
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SubmitButtonUpdate() //Code for checking if there is anything in the input field to activate the button
    {
        if (nameInput.text.ToString() != "")
        {
            submitButton.SetActive(true);
        }
        else
        {
            submitButton.SetActive(false);
        }
    }


    private void UpdateText() //Code for updating the pet's stats
    {
        nameText.text = myPet.Name;
        energyText.text = "Energy: " + myPet.Energy.ToString();
        happinessText.text = "Happiness: " + myPet.Happiness.ToString();
        hungerText.text = "Hunger: " + myPet.Hunger.ToString();
    }

    private void PetTimePassing() //Code that runs every half second to change the pet's stats, then checks if any meets the game over requirements
    {
        myPet.Hunger += 1;

        myPet.Energy -= 1;

        myPet.Happiness -= 3 ;

        //Debug.Log("Time Passes:");

        if (CheckGameOver())
        {
            GameOver();
        }
        else
        {
            UpdateText();
        }
    }

    private bool CheckGameOver() //Runs an if statement that checks if anything of the pets stats are at the limit
    {
        if (myPet.Hunger >= 100 || myPet.Energy == 0 || myPet.Hunger == 0)
        {
            return true;
        } else
        {
            return false;
        }
    }

    private void GameOver() //GameOver code, stops coroutine and changes text to reflect
    {
        StopCoroutine(PassingTime());
        nameText.text = "You Failed";
        newPetButton.SetActive(true);
    }

    public void CheckThreshold() //Changes the color of the stat that is near it's threshold to red so that the player can notice and act
    {
        if (myPet.Happiness < 15)
        {
            happinessText.color = Color.red;
        } else
        {
            happinessText.color = Color.black;
        }

        if (myPet.Energy < 15)
        {
            energyText.color = Color.red;
        }
        else
        {
            energyText.color = Color.black;
        }

        if (myPet.Hunger > 85)
        {
            hungerText.color = Color.red;
        } else
        {
            hungerText.color = Color.black;
        }
    }

    IEnumerator PassingTime() //Coroutine to pass the time, runs every half second
    {
        while (true)
        {
            PetTimePassing();
            CheckThreshold();
            yield return new WaitForSeconds(timeInterval);
        }
    }
}
