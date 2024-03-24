using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setActive : MonoBehaviour
{
    public GameObject scarecrowPanel;

    public void scarecrowPanel_Active()
    {
        scarecrowPanel.gameObject.SetActive(true);
        Debug.Log(scarecrowPanel);
    }
}
