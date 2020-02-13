using System;
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
    [SerializeField] private GameObject gameModePanel;

    [Header("Animations")] 
    [SerializeField] private Animator anim;
    [SerializeField] private string niveauTriggerName = "Niveau";
    [SerializeField] private string disableNiveauTriggerName = "DisableNiveau";
    private bool niveauEnable = false;
    
    private void OnEnable()
    {
        Debug.Log(anim.GetCurrentAnimatorStateInfo(0));
        if(DataManager.Instance != null)
            DataManager.Instance.onDataLoaded.AddListener(EnableButtonLevel);
    }

    private void OnDisable()
    {
        if(DataManager.Instance != null)
            DataManager.Instance.onDataLoaded.RemoveListener(EnableButtonLevel);
    }
    
    public void EnableNiveauPanel()
    {
        if (!this.niveauEnable)
        {
            this.anim.SetTrigger(this.niveauTriggerName);
            this.niveauEnable = true;
        }
    }

    public void DisableNiveauPanel()
    {
        if (this.niveauEnable)
        {
            this.anim.SetTrigger(this.disableNiveauTriggerName);
            this.niveauEnable = false;
        }
    }
    
    public void EnableCreditsPanel()
    {

    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void EnableButtonLevel(int index, bool value)
    {
        niveauxButtons[index].interactable = value;
    }
}