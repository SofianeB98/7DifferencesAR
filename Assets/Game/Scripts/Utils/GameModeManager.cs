using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    [SerializeField] private GameTimer gameTimer;

    [SerializeField] private GameObject[] markerUiFreeMode;
    [SerializeField] private GameObject[] markerUiChronoMode;
    [SerializeField] private GameObject[] markerUiLifeMode;
    
    private void Start()
    {
        if (GameModeSettings.gameMode != GameModeType.CHRONO)
            this.gameTimer.enabled = false;
    }

    public void CheckModeAndUi()
    {
        for (int i = 0; i < markerUiFreeMode.Length; i++)
        {
            markerUiFreeMode[i].SetActive(false);
        }
        
        for (int i = 0; i < markerUiLifeMode.Length; i++)
        {
            markerUiLifeMode[i].SetActive(false);
        }
        
        for (int i = 0; i < markerUiChronoMode.Length; i++)
        {
            markerUiChronoMode[i].SetActive(false);
        }
        
        switch (GameModeSettings.gameMode)
        {
            case GameModeType.FREE:
                for (int i = 0; i < markerUiFreeMode.Length; i++)
                {
                    markerUiFreeMode[i].SetActive(true);
                }
                break;
            
            case GameModeType.LIFE:
                for (int i = 0; i < markerUiLifeMode.Length; i++)
                {
                    markerUiLifeMode[i].SetActive(true);
                }
                break;
            
            case GameModeType.CHRONO:
                for (int i = 0; i < markerUiChronoMode.Length; i++)
                {
                    markerUiChronoMode[i].SetActive(true);
                }
                break;
        }
    }
}
