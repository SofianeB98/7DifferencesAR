using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class MenuManager : MonoBehaviour
{
    [Header("Buttons")] 
    [SerializeField] private Button[] niveauxButtons;
    private int[] activeNiveaux;
    
    [Header("Panels")] 
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject niveauxPanel;


    public void EnableNiveauPanel()
    {
        this.niveauxPanel.SetActive(!this.niveauxPanel.activeSelf);
    }

    public void EnableCreditsPanel()
    {
        
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
