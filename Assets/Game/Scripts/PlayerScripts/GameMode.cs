using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMode : MonoBehaviour
{
    // Button State
    [SerializeField] private Button buttonFreeMode;
    [SerializeField] private Button buttonLifeMode;
    [SerializeField] private Button buttonTimerMode;

    // Button Background
    [SerializeField] private Sprite buttonEnableBackground;
    [SerializeField] private Sprite buttonDisableBackground;

    // Start is called before the first frame update
    void Start()
    {
        if (GameModeSettings.freeModeEnable)
        {
            buttonFreeMode.GetComponent<Image>().sprite = buttonEnableBackground;
            buttonLifeMode.GetComponent<Image>().sprite = buttonDisableBackground;
            buttonTimerMode.GetComponent<Image>().sprite = buttonDisableBackground;
        }
        else if(GameModeSettings.lifeModeEnable)
        {
            buttonFreeMode.GetComponent<Image>().sprite = buttonDisableBackground;
            buttonLifeMode.GetComponent<Image>().sprite = buttonEnableBackground;
            buttonTimerMode.GetComponent<Image>().sprite = buttonDisableBackground;
        }
        else if (GameModeSettings.timerModeEnable)
        {
            buttonFreeMode.GetComponent<Image>().sprite = buttonDisableBackground;
            buttonLifeMode.GetComponent<Image>().sprite = buttonDisableBackground;
            buttonTimerMode.GetComponent<Image>().sprite = buttonEnableBackground;
        }
    }

    public void ActivateFreeMode()
    {
        GameModeSettings.freeModeEnable = true;
        GameModeSettings.lifeModeEnable = false;
        GameModeSettings.timerModeEnable = false;

        buttonFreeMode.GetComponent<Image>().sprite = buttonEnableBackground;
        buttonLifeMode.GetComponent<Image>().sprite = buttonDisableBackground;
        buttonTimerMode.GetComponent<Image>().sprite = buttonDisableBackground;
    }

    public void ActivateLifeMode()
    {
        GameModeSettings.freeModeEnable = false;
        GameModeSettings.lifeModeEnable = true;
        GameModeSettings.timerModeEnable = false;

        buttonFreeMode.GetComponent<Image>().sprite = buttonDisableBackground;
        buttonLifeMode.GetComponent<Image>().sprite = buttonEnableBackground;
        buttonTimerMode.GetComponent<Image>().sprite = buttonDisableBackground;
    }

    public void ActivateTimerMode()
    {
        GameModeSettings.freeModeEnable = false;
        GameModeSettings.lifeModeEnable = false;
        GameModeSettings.timerModeEnable = true;

        buttonFreeMode.GetComponent<Image>().sprite = buttonDisableBackground;
        buttonLifeMode.GetComponent<Image>().sprite = buttonDisableBackground;
        buttonTimerMode.GetComponent<Image>().sprite = buttonEnableBackground;
    }
}