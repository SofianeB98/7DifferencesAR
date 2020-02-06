using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class IndicesManager : MonoBehaviour
{
    [SerializeField] private UnityEvent[] onIndiceUsed;
    private int currentIndices = 0;

    [SerializeField] private TextMeshPro indicesText;
    
    private void Start()
    {
        ResetIndices();
    }
    
    public void ResetIndices()
    {
        this.currentIndices = 0;
        
        this.indicesText.text = "Indices - " + (this.onIndiceUsed.Length - currentIndices).ToString() + "/" +
                                this.onIndiceUsed.Length.ToString();
    }
    
    public void UseIndices()
    {
        if (this.currentIndices >= this.onIndiceUsed.Length)
            return;

        this.onIndiceUsed[this.currentIndices++].Invoke();
        
        this.indicesText.text = "Indices - " + (this.onIndiceUsed.Length - currentIndices).ToString() + "/" +
                                this.onIndiceUsed.Length.ToString();
    }
}
