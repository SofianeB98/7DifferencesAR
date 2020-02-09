using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro shootText;
    
    [SerializeField] private UnityEvent onShotNumberEmpty;

    // Life variables
    [SerializeField] private int defaultShotNumber = GameModeSettings.defaultLife;
    private int currentShotNumber = GameModeSettings.defaultLife;

    // Timer variables
    [SerializeField] private float time;
    [SerializeField] private int timeToInt;
    
    private void Awake()
    {
        this.currentShotNumber = defaultShotNumber;

        // Timer mode enable
        if (GameModeSettings.timerModeEnable)
        {
            time = GameModeSettings.defaultTimer;
        }
    }

    private void Update()
    {
        // Timer mode enable
        if (GameModeSettings.timerModeEnable)
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

        // Timer mode enable
        if (GameModeSettings.timerModeEnable)
        {
            time = GameModeSettings.defaultTimer;
        }
    }
}