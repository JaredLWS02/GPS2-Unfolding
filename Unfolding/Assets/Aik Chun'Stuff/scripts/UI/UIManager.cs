using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUi;
    [SerializeField] private GameObject camUI;
    [SerializeField] private GameObject settingsUi;
    [SerializeField] private GameObject gameplayCamera;
    [SerializeField] private CameraPan pan;
    public void StartGame()
    {
        //turn off all main menu ui
        camUI.SetActive(false);
        mainMenuUi.SetActive(false);

        // turn on all gameplay related objects
        gameplayCamera.SetActive(true);
    }

    public void ShowSettings()
    {
        //turn off all main menu ui
        pan.Settings();
        mainMenuUi.SetActive(false);

        // turn on all settings related objects
        settingsUi.SetActive(true);

    }

    public void BackMainMenu()
    {
        // turn off settings Ui
        pan.MainMenu();
        settingsUi.SetActive(false);

        //turn off all main menu ui
        mainMenuUi.SetActive(true);

    }
    public void Exitgame()
    {
        Application.Quit();
    }
}
