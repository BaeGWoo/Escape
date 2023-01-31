using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Loading : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Image progressBar;

    private string loadSceneName;



    private static Loading instance;
    public static Loading Instance
    {
        get 
        {
            if (instance == null)
            { 
                var obj = FindObjectOfType<Loading>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                { 
                    instance = Create();
                }
            }
            return instance;
        }
    }
    private static Loading Create()
    {
        return Instantiate(Resources.Load<Loading>("LoadingUI"));
    }

    private void Awake()
    {
        if (instance != this)
        { 
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject); 
    }

    public void LoadScene(string scenename)
    { 
        gameObject.SetActive(true);
        SceneManager.sceneLoaded += OnSceneLoaded;
        loadSceneName = scenename;
        StartCoroutine(LoadSceneProcess());
    }

    private IEnumerator LoadSceneProcess()
    {
        progressBar.fillAmount = 0f;
        yield return StartCoroutine(Fade(true));

        AsyncOperation op = SceneManager.LoadSceneAsync(loadSceneName);
        op.allowSceneActivation = false;            //����� �غ�Ǵ� ��� ��� Ȱ��ȭ��ų ������ ��� ����

        float timer = 0f;
        while (!op.isDone) // ���� ���� �ҷ����� �ʾҴٸ�
        {
            yield return null;
            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if (progressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == loadSceneName)
        {
            StartCoroutine(Fade(false));
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private IEnumerator Fade(bool isFadeIn)
    {
        float timer = 0f;
        while (timer <= 1f)
        {
            yield return null;
            timer += Time.unscaledDeltaTime * 3f;
            canvasGroup.alpha = isFadeIn ? Mathf.Lerp(0f, 1f, timer) : Mathf.Lerp(1f, 0f, timer);
        }

        if (!isFadeIn)
        { 
            gameObject.SetActive(false);
        }

    }

}
