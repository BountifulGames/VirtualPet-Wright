using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////
//Assignment/Lab/Project: Vitual Pet
//Name: Hunter Wright
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 2/26/2024
/////////////////////////////////////////////
public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuBackground;
    [SerializeField] private GameObject instructionsBackground;

    // Code for running the main menu UI
    public void OnPlayButtonPress()
    {
        SceneManager.LoadScene("VirtualPet");
    }

    public void OnInstructionsButtonPress()
    {
        mainMenuBackground.SetActive(false);
        instructionsBackground.SetActive(true);
    }

    public void OnQuitButtonPress()
    {
        Application.Quit();
    }

    public void OnBackButtonPress()
    {
        instructionsBackground.SetActive(false);
        mainMenuBackground.SetActive(true);
    }
}
