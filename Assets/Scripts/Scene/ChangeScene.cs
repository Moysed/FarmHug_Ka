using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    FadeInOut fade;

    void Start()
    {
        fade = FindAnyObjectByType<FadeInOut>();
    }

    public IEnumerator _ChaneScene()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneName);
    }

    // Update is called once per frame
    public void changeScene()
    {
        StartCoroutine(_ChaneScene());
    }
}
