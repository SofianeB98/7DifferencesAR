using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro shootText;
    
    [SerializeField] private UnityEvent onShotNumberEmpty;

    // Life variables
    [SerializeField] private int defaultShotNumber = 10;
    private int currentShotNumber = 10;

    private void Awake()
    {
        this.currentShotNumber = GameModeSettings.gameMode == GameModeType.LIFE ? this.defaultShotNumber : 999999;
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
        this.currentShotNumber = GameModeSettings.gameMode == GameModeType.LIFE ? this.defaultShotNumber : 999999;
        this.shootText.text = "Tirs - " + this.currentShotNumber.ToString("00") + "/" + this.defaultShotNumber.ToString("00");
    }
}