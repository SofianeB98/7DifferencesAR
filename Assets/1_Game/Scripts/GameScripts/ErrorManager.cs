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
        if (this.errors.Contains(error))
        {
            if (error != null)
            {
                if (!error.IsChecked)
                {
                    this.foundedError++;
                    error.SetChecked(true);
                    this.OnErrorFounded.Invoke(error);
                }
            }

            if (this.foundedError == this.errors.Count)
            {
                //Victory
                this.onAllErrorFounded.Invoke();
            }
        }
    }
}
