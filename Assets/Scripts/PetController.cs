using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PetController : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private GameObject submitButton;
    [SerializeField] private GameObject feedButton;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject restButton;
    [SerializeField] private GameObject submitBackground;
    [SerializeField] private GameObject petBackground;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private TMP_Text happinessText;
    [SerializeField] private TMP_Text hungerText;

    private Pet myPet;
    private float timeInterval = 2f;

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
        nameText.text = myPet.name;
        energyText.text = "Energy: " + myPet.Energy.ToString();
        happinessText.text = "Happiness: " + myPet.Happiness.ToString();
        hungerText.text = "Hunger: " + myPet.Hunger.ToString();
    }

    private void PetTimePassing()
    {
        myPet.Hunger += 1;

        myPet.Energy -= 1;

        myPet.Happiness -= 1;

        Debug.Log("Time Passes:");
        UpdateText();
    }

    IEnumerator PassingTime()
    {
        while (true)
        {
            PetTimePassing();
            yield return new WaitForSeconds(timeInterval);
        }
    }
}
