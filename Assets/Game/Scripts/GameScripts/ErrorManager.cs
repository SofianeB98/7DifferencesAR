using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ErrorManager : MonoBehaviour
{
    public static ErrorManager Instance;
    
    [SerializeField] private List<Error> errors = new List<Error>();
    private int foundedError = 0;

    [SerializeField] private ErrorEvent OnErrorFounded;
    public IntEvent onAllErrorFounded;

    [SerializeField] private TextMeshPro errorFoundedText;
    
    public List<Error> Errors
    {
        get => this.errors;
    }

    private void Start()
    {
        Instance = this;
        
        InitError();
    }

    private void InitError()
    {
        this.foundedError = 0;
        
        this.errorFoundedText.text = "Erreurs - " + this.foundedError.ToString() + "/" + this.errors.Count.ToString();
        
        for (int i = 0; i < errors.Count; i++)
        {
            this.errors[i].SetChecked(false);
        }
    }

    public void CheckSelectedError(Error error)
    {
        if (GameManager.instance != null)
            if (!GameManager.instance.GameStarted)
                return;

        if (error != null)
        {
            Debug.Log("Une erreur est a check");
            if (this.errors.Contains(error))
            {
                Debug.Log("L erreur est contenu");
                if (!error.IsChecked)
                {
                    Debug.Log("l erreur est desomais valider !");
                    this.foundedError++;
                    error.SetChecked(true);
                    this.OnErrorFounded.Invoke(error);
                    
                    this.errorFoundedText.text = "Erreurs - " + this.foundedError.ToString() + "/" + this.errors.Count.ToString();
                }

                if (this.foundedError == this.errors.Count)
                {
                    //Victory
                    this.onAllErrorFounded.Invoke(GameManager.instance.Level);
                }
            }
        }
    }

    public void RestartErrorManager()
    {
        this.foundedError = 0;
        for (int i = 0; i < errors.Count; i++)
        {
            this.errors[i].ResetError();
        }
    }
}