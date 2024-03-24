using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Vector3 Spawnpos;
    Animator animator;
    BoxCollider2D collider;
    public bool onAnimrun;
    public static PlayerScript singleton;
 
    void Awake()
    {
        singleton = this;
    }
 
    void Start()
    {
        Spawnpos = transform.position;
        collider = GetComponentInChildren<BoxCollider2D>();
        animator = GetComponent<Animator>();
        onAnimrun = false;
    }
 
    public void ChangeAnimationstate(string animstate1, string animstage2)
    {
        animator.SetBool(animstate1 , true);
        animator.SetBool(animstage2 , false);
    }
}
