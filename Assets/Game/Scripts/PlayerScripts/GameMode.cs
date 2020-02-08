using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMode : MonoBehaviour
{
    // Game Mode State
    [SerializeField] public bool freeModeEnable = true;
    [SerializeField] public bool lifeModeEnable = false;
    [SerializeField] public bool timerModeEnable = false;

    // Game Mode Data
    [SerializeField] public int defaultLife = 10;
    [SerializeField] public int defaultTimer = 180;

    // Button State
    [SerializeField] private Button buttonFreeMode;
    [SerializeField] private Button buttonLifeMode;
    [SerializeField] private Button buttonTimerMode;

    // Button background
    [SerializeField] private Sprite buttonEnableBackground;
    [SerializeField] private Sprite buttonDisableBackground;

    // Start is called before the first frame update
    void Start()
    {
        buttonFreeMode.GetComponent<Image>().sprite = buttonEnableBackground;
        buttonLifeMode.GetComponent<Image>().sprite = buttonDisableBackground;
        buttonTimerMode.GetComponent<Image>().sprite = buttonDisableBackground;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ActivateFreeMode()
    {
        freeModeEnable = true;
        lifeModeEnable = false;
        timerModeEnable = false;

        buttonFreeMode.GetComponent<Image>().sprite = buttonEnableBackground;
        buttonLifeMode.GetComponent<Image>().sprite = buttonDisableBackground;
        buttonTimerMode.GetComponent<Image>().sprite = buttonDisableBackground;
    }

    public void ActivateLifeMode()
    {
        freeModeEnable = false;
        lifeModeEnable = true;
        timerModeEnable = false;

        buttonFreeMode.GetComponent<Image>().sprite = buttonDisableBackground;
        buttonLifeMode.GetComponent<Image>().sprite = buttonEnableBackground;
        buttonTimerMode.GetComponent<Image>().sprite = buttonDisableBackground;
    }

    public void ActivateTimerMode()
    {
        freeModeEnable = false;
        lifeModeEnable = false;
        timerModeEnable = true;

        buttonFreeMode.GetComponent<Image>().sprite = buttonDisableBackground;
        buttonLifeMode.GetComponent<Image>().sprite = buttonDisableBackground;
        buttonTimerMode.GetComponent<Image>().sprite = buttonEnableBackground;
    }
}