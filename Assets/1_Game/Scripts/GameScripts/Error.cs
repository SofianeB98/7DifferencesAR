using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Error : MonoBehaviour
{
    public bool IsChecked { get; private set; }

    public void SetChecked(bool val)
    {
        this.IsChecked = val;
    }
}
