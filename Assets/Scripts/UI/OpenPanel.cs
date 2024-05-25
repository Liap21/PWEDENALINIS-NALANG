using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public GameObject Panel;
    public GameObject inventoryPanel;
    public bool usingPausePanel;


    void Start()
    {
        //isPaused = false;
        Panel.SetActive(false);
        inventoryPanel.SetActive(false);
        usingPausePanel = false;
    }

    public void PanelOpener()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
            MenuButtonClicked();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        usingPausePanel = true;
    }

    public void ResumeGame()
    {
        inventoryPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void MenuButtonClicked()
    {
        if (Panel.activeSelf)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void SwitchPanels()
    {
        usingPausePanel = !usingPausePanel;
        if(usingPausePanel)
        {
            Panel.SetActive(true);
            inventoryPanel.SetActive(false);
        }
        else
        {
            Panel.SetActive(false);
            inventoryPanel.SetActive(true);
        }
    }
}
