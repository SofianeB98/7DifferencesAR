using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;

    public Data data;
    
    public IntBoolEvent onDataLoaded;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        
    }

    private void OnEnable()
    {
        if(!PlayerPrefs.HasKey(data.levelKey + 0))
            data.UnlockLevel(0);
        
        for (int i = 0; i < data.unlockedLevel.Length; i++)
        {
            if (i == 0)
            {
                data.unlockedLevel[i] = true;
                onDataLoaded.Invoke(i, true);
            }
            else
            {
                data.unlockedLevel[i] = false;
                onDataLoaded.Invoke(i, false);
            }
        }
        
        //Check si les PlayerPref exist
        for (int i = 0; i < data.unlockedLevel.Length; i++)
        {
            if (!PlayerPrefs.HasKey(data.levelKey + i))
                continue;
            
            bool val = PlayerPrefs.GetInt(data.levelKey + i) == 0 ? true : false;
            data.unlockedLevel[i] = val;
            onDataLoaded.Invoke(i, val);
        }
        
        Debug.Log("On enbale data manager");
    }

}
