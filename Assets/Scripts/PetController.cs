using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PetController : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private GameObject submitButton;
    [SerializeField] private GameObject submitBackground;
    [SerializeField] private GameObject petBackground;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private TMP_Text happinessText;
    [SerializeField] private TMP_Text hungerText;

    private Pet myPet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SubmitButtonUpdate();
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

    public void OnSubmitButtonPress()
    {
        submitBackground.SetActive(false);
        petBackground.SetActive(true);

        myPet = new Pet(nameInput.text.ToString());

        UpdateText();
    }

    private void UpdateText()
    {
        nameText.text = myPet.name;
        energyText.text = myPet.energy.ToString();
        happinessText.text = myPet.happiness.ToString();
        hungerText.text = myPet.hunger.ToString();
    }
}
