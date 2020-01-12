using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private int defaultShotNumber = 10;
    private int currentShotNumber = 10;

    [SerializeField] private UnityEvent onShotNumberEmpty;
    [SerializeField] private TextMeshProUGUI txt;
    private void Awake()
    {
        this.currentShotNumber = defaultShotNumber;
    }

    private void Update()
    {
        txt.text = this.currentShotNumber.ToString();
    }

    public void Shoot(Error er)
    {
        if (er == null)
            this.txt.text = "NO ERRR MERDE";
        
        this.currentShotNumber--;
        if (this.currentShotNumber == 0)
        {
            //Defeat
            onShotNumberEmpty.Invoke();
        }
    }
}
