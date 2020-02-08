using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private int defaultShotNumber = 10;
    private int currentShotNumber = 10;

    [SerializeField] private TextMeshPro shootText;
    
    [SerializeField] private UnityEvent onShotNumberEmpty;

    // Game Mode Script
    [SerializeField] private GameMode gameMode;

    // Timer variables
    [SerializeField] private float time;
    [SerializeField] private int timeToInt;
    
    private void Awake()
    {
        this.currentShotNumber = defaultShotNumber;

        if (gameMode.timerModeEnable)
        {
            time = gameMode.defaultTimer;
        }
    }

    private void Update()
    {
        if (gameMode.timerModeEnable)
        {
            timeToInt = Mathf.RoundToInt(time);
            time -= Time.deltaTime;

            if (time <= 0)
            {
                //Defeat
                onShotNumberEmpty.Invoke();
            }
        } 
    }

    public void Shoot()
    {
        if(GameManager.instance != null)
            if (!GameManager.instance.GameStarted)
                return;
                
        if (this.currentShotNumber <= 0)
            return;
        
        this.currentShotNumber--;

        this.shootText.text = "Tirs - " + this.currentShotNumber.ToString("00") + "/" + this.defaultShotNumber.ToString("00"); 
        
        if (this.currentShotNumber == 0)
        {
            //Defeat
            onShotNumberEmpty.Invoke();
        }
    }

    public void RestartPlayerManager()
    {
        this.currentShotNumber = this.defaultShotNumber;
        this.shootText.text = "Tirs - " + this.currentShotNumber.ToString("00") + "/" + this.defaultShotNumber.ToString("00");

        if (gameMode.timerModeEnable)
        {
            time = gameMode.defaultTimer;
        }
    }
}