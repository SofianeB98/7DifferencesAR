using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private int defaultShotNumber = 10;
    private int currentShotNumber = 10;

    [SerializeField] private UnityEvent onShotNumberEmpty;
    
    private void Awake()
    {
        this.currentShotNumber = defaultShotNumber;
    }
    
    public void Shoot()
    {
        if(GameManager.instance != null)
            if (!GameManager.instance.GameStarted)
                return;
                
        if (this.currentShotNumber <= 0)
            return;
        
        this.currentShotNumber--;
        if (this.currentShotNumber == 0)
        {
            //Defeat
            onShotNumberEmpty.Invoke();
        }
    }

    public void RestartPlayerManager()
    {
        this.currentShotNumber = this.defaultShotNumber;
    }
}
