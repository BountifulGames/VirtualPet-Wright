using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PetController : MonoBehaviour
{
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

    public void OnSubmitButtonPress()
    {
        submitBackground.SetActive(false);
        petBackground.SetActive(true);

        myPet = new Pet(nameInput.text.ToString());

        UpdateText();

        StartCoroutine(PassingTime());
    }

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

    public void OnNewPetButtonPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SubmitButtonUpdate()
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


    private void UpdateText()
    {
        nameText.text = myPet.Name;
        energyText.text = "Energy: " + myPet.Energy.ToString();
        happinessText.text = "Happiness: " + myPet.Happiness.ToString();
        hungerText.text = "Hunger: " + myPet.Hunger.ToString();
    }

    private void PetTimePassing()
    {
        myPet.Hunger += 1;

        myPet.Energy -= 1;

        myPet.Happiness -= 3 ;

        Debug.Log("Time Passes:");

        if (CheckGameOver())
        {
            GameOver();
        }
        else
        {
            UpdateText();
        }
    }

    private bool CheckGameOver()
    {
        if (myPet.Hunger >= 100 || myPet.Energy == 0 || myPet.Hunger == 0)
        {
            return true;
        } else
        {
            return false;
        }
    }

    private void GameOver()
    {
        StopCoroutine(PassingTime());
        nameText.text = "You Failed";
        newPetButton.SetActive(true);
    }

    public void CheckThreshold()
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

    IEnumerator PassingTime()
    {
        while (true)
        {
            PetTimePassing();
            CheckThreshold();
            yield return new WaitForSeconds(timeInterval);
        }
    }
}
