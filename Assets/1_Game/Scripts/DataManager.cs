using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;
    
    public bool[] unlockedLevel = new bool[16];
    public string levelKey = "AR7Diff_Level";
    
    public IntBoolEvent onDataLoaded;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
        
        
        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        for (int i = 0; i < unlockedLevel.Length; i++)
        {
            if (i == 0)
            {
                unlockedLevel[i] = true;
                onDataLoaded.Invoke(i, true);
            }
            else
            {
                unlockedLevel[i] = false;
                onDataLoaded.Invoke(i, false);
            }
            
            
        }
        
        //Check si les PlayerPref exist
        for (int i = 0; i < unlockedLevel.Length; i++)
        {
            if (!PlayerPrefs.HasKey(levelKey + i))
                continue;
            
            bool val = PlayerPrefs.GetInt(levelKey + i) == 0 ? true : false;
            unlockedLevel[i] = val;
            onDataLoaded.Invoke(i, val);
        }
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        for (int i = 0; i < unlockedLevel.Length; i++)
        {
            onDataLoaded.Invoke(i, unlockedLevel[i]);
        }
    }
    
    /// <summary>
    /// Le parametre doit être le numero du level en cours
    /// </summary>
    /// <param name="level"></param>
    public void UnlockLevel(int level)
    {
        if (level >= unlockedLevel.Length)
            return;
        
        unlockedLevel[level] = true;
        
        PlayerPrefs.SetInt(levelKey + level, 0);
    }

    public void LockLevel(int level)
    {
        if (level >= unlockedLevel.Length)
            return;
        
        unlockedLevel[level] = false;
        
        PlayerPrefs.SetInt(levelKey + level, 1);
    }
}
