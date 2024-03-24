using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTime : ChangeScene
{
    private ChangeScene _changeScene;
    public float startTime;

    private void Start()
    {
        _changeScene = new ChangeScene();
    }
    // Update is called once per frame
    void Update()
    {
        startTime -= Time.deltaTime;
        if(startTime <= 0)
        {
            changeScene();
        }
    }
}
