using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    private bool isOptionsPanelActive = false;

    public void SetActiveOptionsMenu()
    {
        isOptionsPanelActive = !isOptionsPanelActive;
        optionsPanel.SetActive(isOptionsPanelActive);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
