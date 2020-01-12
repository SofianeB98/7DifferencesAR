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

    [Header("Animations")] 
    [SerializeField] private Animator anim;
    [SerializeField] private string niveauTriggerName = "Niveau";

    public void EnableNiveauPanel()
    {
        this.anim.SetTrigger(this.niveauTriggerName);
    }

    public void EnableCreditsPanel()
    {
        
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
