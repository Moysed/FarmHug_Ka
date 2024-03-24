using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManagement : MonoBehaviour
{
    public Animator animator;
    public Text coin;
    public static CoinManagement singleton;
    //Start is called before the first frame update 
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        //Make this active and only instance 
        singleton = this;
    }
    public void UpdateCoin(int _coin)
    { 
        coin.text = _coin.ToString();
    }
 
    public void AnimLosetrgigger()
    {
        animator.SetBool("IsBuy", true);
        Invoke("ResetBuyAnim", 0.2f);
    }
 
    public void AnimGetmoneytrgigger()
    {
        animator.SetBool("IsGetMoney", true);
        Invoke("ResetBuyAnim", 0.2f);
    }
    public void ResetBuyAnim()
    {
        animator.SetBool("IsBuy", false);
        animator.SetBool("IsGetMoney", false);
    }
}