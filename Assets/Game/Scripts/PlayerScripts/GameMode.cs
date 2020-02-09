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

    // Slider UI
    [SerializeField] private Slider timerSlider;
    [SerializeField] private Slider lifeSlider;

    // Slider Text
    [SerializeField] private Text timerText;
    [SerializeField] private Text lifeText;

    // Game Mode Settings
    public bool freeModeEnable;
    public bool lifeModeEnable;
    public bool timerModeEnable;
    public int defaultLife;
    public int defaultTimer;

    // Start is called before the first frame update
    void Start()
    {
        timerSlider.value = GameModeSettings.defaultTimer;
        lifeSlider.value = GameModeSettings.defaultLife;

        SetTextTimer(GameModeSettings.defaultTimer);
        SetTextLife(GameModeSettings.defaultLife);

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

    private void Update()
    {
        // Show Game Mode Settings in Unity inspector
        freeModeEnable = GameModeSettings.freeModeEnable;
        lifeModeEnable = GameModeSettings.lifeModeEnable;
        timerModeEnable = GameModeSettings.timerModeEnable;
        defaultLife = GameModeSettings.defaultLife;
        defaultTimer = GameModeSettings.defaultTimer;
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

    public void SetTimer(float timer)
    {
        GameModeSettings.defaultTimer = (int)timer;
    }

    public void SetTextTimer(float timer)
    {
        timerText.text = timer.ToString() + " secondes";
    }

    public void SetLife(float life)
    {
        GameModeSettings.defaultLife = (int)life;
    }

    public void SetTextLife(float life)
    {
        lifeText.text = "Nombre de vie : " + life.ToString();
    }
}