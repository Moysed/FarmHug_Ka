using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellManager : MonoBehaviour
{
    //public static SellManager singleton;
    CoinManagement CoinManagement;
    Inventory inventory;
    SFXManager sfx;
    public float sellTime = 0;

    // Update is called once per frame
    private void Awake()
    {
        sfx = GameObject.FindGameObjectWithTag("SFX").GetComponent<SFXManager>();
    }

    public void AutoSell()
    {
        sellTime += Time.deltaTime;
        if (sellTime >= 45)
        {
            sellTime = 0;
            sfx.PlaySFX(sfx.Sold);
        }
    }
}
