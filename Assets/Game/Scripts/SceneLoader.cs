﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float waitTime = 2.0f;
    [SerializeField] private float fadeScreenTime = 2.0f;
    [SerializeField] private UnityEvent onSceneLoading;
    
    
    public void LoadScene(int index)
    {
        StartCoroutine(LoadSceneAsync(index));
    }

    public void SetWaitTime(float time)
    {
        this.waitTime = time;
    }
    
    private IEnumerator LoadSceneAsync(int index)
    {
        yield return new WaitForSeconds(this.waitTime);
        this.onSceneLoading.Invoke();
        yield return new WaitForSeconds(this.fadeScreenTime);
        
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            if (loadAsync.progress >= 0.9f)
            {
                loadAsync.allowSceneActivation = true;
            }
            
            yield return new WaitForSeconds(0.1f);
        }
        
        yield break;
    }
}
