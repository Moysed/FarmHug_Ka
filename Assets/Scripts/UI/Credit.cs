using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    public static Credit singleton;
    public GameObject credit;

    private void Awake()
    {
        singleton = this;
    }

    public void unShow()
    {
        credit.gameObject.SetActive(false);
    }
}
