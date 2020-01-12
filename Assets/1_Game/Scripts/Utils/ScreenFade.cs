using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    [SerializeField] private FadeType fade;
    [SerializeField] private RawImage screen;
    [SerializeField] private float fadetime = 2.0f;
    [SerializeField] private bool fadeOnStart = false;
    void Start()
    {
        if(this.fadeOnStart)
            StartCoroutine(Fade(this.fade == FadeType.FadeIn ? 1 : 0, 
                                        this.fade == FadeType.FadeIn ? 0 : 1));
    }

    public void LaunchFade(bool fadeIn)
    {
        StartCoroutine(Fade(fadeIn ? 1 : 0, 
                                    fadeIn ? 0 : 1));
    }
    
    private IEnumerator Fade(float from, float to)
    {
        Color col = this.screen.color;
        col.a = from;
        this.screen.color = col;

        float currentFade = 0.0f;
        float waitTime = 0.1f / fadetime;
        
        while (currentFade < 1.0f)
        {
            yield return new WaitForSeconds(waitTime);
            currentFade += waitTime;
            col.a = Mathf.Lerp(from, to, currentFade);
            this.screen.color = col;
        }
        
        yield break;
    }

}