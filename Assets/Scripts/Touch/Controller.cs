using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    FadeInOut fade;

    // Start is called before the first frame update
    void Start()
    {
        fade = FindAnyObjectByType<FadeInOut>();

        fade.FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
