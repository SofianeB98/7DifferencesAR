using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour
{
    [Header("Parameter")] 
    [SerializeField] private float gameTime = 120.0f;
    [SerializeField] private float[] onSpecifiedSecondElapsed_Value;
    private float currentGameTimer = 0.0f;
    
    [Header("Events")] 
    [SerializeField] private FloatEvent OnSecondElapsed_GameTimer;
    [Space(5)]
    [SerializeField] private UnityEvent[] OnSpecifiedSecondElapsed;
    [Space(10)]
    [SerializeField] private UnityEvent OnTimeElapsed_GameTimer;
    
    // ------------------
    private Coroutine timer;
    private WaitForSeconds oneSecond;
    private int currentIndexSpecifiedSeconds = 0;
    
    private void Start()
    {
        this.oneSecond = new WaitForSeconds(1.0f);
        this.currentGameTimer = this.gameTime;
        this.OnSecondElapsed_GameTimer.Invoke(this.currentGameTimer);
    }

    #region Timer Functions

    public void StartGameTimer()
    {
        if(timer == null && GameModeSettings.gameMode == GameModeType.CHRONO)
            timer = StartCoroutine(nameof(GameTimerClock));
    }

    public void StopGameTimer()
    {
        if (GameModeSettings.gameMode != GameModeType.CHRONO)
            return;
        
        StopCoroutine(timer);
        timer = null;
    }

    public void StopAndResetGameTimer()
    {
        if (GameModeSettings.gameMode != GameModeType.CHRONO)
            return;
            
        StartGameTimer();
        ResetGameTimer();
        OnSecondElapsed_GameTimer.Invoke(this.currentGameTimer);
    }

    #endregion

    #region Utils Functions

    public void SetGameTimer(float time)
    {
        this.currentGameTimer = time;
    }
    
    public void AddTimeToGameTimer(float time)
    {
        this.currentGameTimer += time;
    }

    public void RemoveTimeToGameTimer(float time)
    {
        this.currentGameTimer -= time;
    }

    public void ResetGameTimer()
    {
        if (GameModeSettings.gameMode != GameModeType.CHRONO)
            return;
        
        this.currentGameTimer = gameTime;
    }
    
    #endregion

    private IEnumerator GameTimerClock()
    {
        while (this.currentGameTimer > 0.0f)
        {
            yield return oneSecond;
            this.currentGameTimer -= 1.0f;
            this.OnSecondElapsed_GameTimer.Invoke(this.currentGameTimer);

            if (this.currentIndexSpecifiedSeconds < this.onSpecifiedSecondElapsed_Value.Length)
            {
                if (this.onSpecifiedSecondElapsed_Value[this.currentIndexSpecifiedSeconds] <= this.currentGameTimer)
                {
                    this.OnSpecifiedSecondElapsed[this.currentIndexSpecifiedSeconds].Invoke();
                    this.currentIndexSpecifiedSeconds++;
                }
            }
            
        }
        
        this.OnTimeElapsed_GameTimer.Invoke();
        
        yield break;
    }
}
