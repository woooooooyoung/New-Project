using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManagerEX : MonoBehaviour
{
    private BaseScene curScene;
    
    public BaseScene CurScene
    {
        get
        {
            if (curScene == null)
                curScene = GameObject.FindObjectOfType<BaseScene>();
    
            return curScene;
        }
    }
   
    public void LoadScene(string sceneName)
    {
        UnitySceneManager.LoadScene(sceneName);
    }

































    /*private LoadingUI loadingUI;
    
    private BaseScene curScene;
    public BaseScene CurScene
    {
        get
        {
            if (curScene == null)
                curScene = GameObject.FindObjectOfType<BaseScene>();
    
            return curScene;
        }
    }
    
    private void Awake()
    {
        LoadingUI loadingUI = Resources.Load<LoadingUI>("UI/LoadingUI");
        this.loadingUI = Instantiate(loadingUI);
        this.loadingUI.transform.SetParent(transform);
    }
    
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadingRoutine(sceneName));
    }
    
    IEnumerator LoadingRoutine(string sceneName)
    {
        loadingUI.SetProgress(0f);
        loadingUI.FadeOut();
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
    
        AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);
        while (!oper.isDone)
        {
            loadingUI.SetProgress(Mathf.Lerp(0.0f, 0.5f, oper.progress));
            yield return null;
        }
    
        if (CurScene != null)
        {
            CurScene.LoadAsync();
            while (CurScene.progress < 1f)
            {
                loadingUI.SetProgress(Mathf.Lerp(0.5f, 1f, CurScene.progress));
                yield return null;
            }
        }
    
        loadingUI.SetProgress(1f);
        loadingUI.FadeIn();
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.5f);
    }*/
}

