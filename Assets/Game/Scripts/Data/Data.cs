using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Data", menuName = "Data/new Data", order = 0)]
public class Data : ScriptableObject
{
    public bool[] unlockedLevel = new bool[16];
    public string levelKey = "AR7Diff_Level";
    
    // ------------------------------------------------------
    
    public void UnlockLevel(int level)
    {
        if (level >= unlockedLevel.Length)
            return;
        
        Debug.Log("Level unlocked");
        
        unlockedLevel[level] = true;
        
        PlayerPrefs.SetInt(levelKey + level, 0);
    }

    // ------------------------------------------------------
    
    public void LockLevel(int level)
    {
        if (level >= unlockedLevel.Length)
            return;
        
        unlockedLevel[level] = false;
        
        PlayerPrefs.SetInt(levelKey + level, 1);
    }
}
