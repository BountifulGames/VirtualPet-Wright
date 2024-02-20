using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuBackground;
    [SerializeField] private GameObject instructionsBackground;
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
