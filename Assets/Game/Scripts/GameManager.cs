using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int level = 1;
    public int Level
    {
        get { return level; }
    }
    
    [SerializeField] private bool gameStarted = false;
    public bool GameStarted => gameStarted;
    
    [SerializeField] private UnityEvent onGameStarted;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    private void Start()
    {
        this.gameStarted = false;
    }

    public void SetGameStarted(bool val)
    {
        this.gameStarted = val;
        
        if(val)
            this.onGameStarted.Invoke();
    }
}
