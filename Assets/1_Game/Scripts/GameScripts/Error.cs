using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Error : MonoBehaviour
{
    public bool IsChecked { get; private set; }
    [SerializeField] private UnityEvent onFounded;
    
    public void SetChecked(bool val)
    {
        this.IsChecked = val;
        
        if(val)
            this.onFounded.Invoke();
    }
}
