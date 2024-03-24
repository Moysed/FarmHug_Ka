using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public GameObject loadingScene;
    public Slider _slider;

    FadeInOut fade;

    void Start()
    {
        fade = FindAnyObjectByType<FadeInOut>();
    }

    public void LoadLevel(int sceneindex)
    {
        StartCoroutine(LoadAsynchronosly(sceneindex));
    }

    IEnumerator LoadAsynchronosly(int sceneindex)
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneindex);
        loadingScene.SetActive(true);
        while (!operation.isDone) 
        {
            float progression = Mathf.Clamp01(operation.progress / 1.0f);
            

            _slider.value = progression;

            Debug.Log(_slider.value);

            yield return null;
        }
    }
}
