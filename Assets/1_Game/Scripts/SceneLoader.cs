using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void LoadScene(int index)
    {
        StartCoroutine(LoadSceneAsync(index));
    }

    private IEnumerator LoadSceneAsync(int index)
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            //Black screen
            //Load bar ?

            if (loadAsync.progress >= 0.9f)
            {
                loadAsync.allowSceneActivation = true;
            }
            
            yield return new WaitForSeconds(0.1f);
        }
        
        yield break;
    }
}
