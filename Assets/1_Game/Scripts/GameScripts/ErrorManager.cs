using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ErrorManager : MonoBehaviour
{
    [SerializeField] private List<Error> errors = new List<Error>();
    private int foundedError = 0;

    [SerializeField] private ErrorEvent OnErrorFounded;
    [SerializeField] private UnityEvent onAllErrorFounded;

    private void Start()
    {
        InitError();
    }

    private void InitError()
    {
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
                }

                if (this.foundedError == this.errors.Count)
                {
                    //Victory
                    this.onAllErrorFounded.Invoke();
                }
            }
        }
    }

    public void RestartErrorManager()
    {
        for (int i = 0; i < errors.Count; i++)
        {
            this.errors[i].ResetError();
        }
    }
}