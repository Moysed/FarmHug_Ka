using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatus : MonoBehaviour
{
    //All Objects
    [SerializeField] protected InfoObject _selfObjectInfo;
    public int ObjectStage = 0;
    public bool collectCheck = false;
    public string ObjectName;
    public bool isLock = true;
    public bool isBought = false;
    public bool isSelected = false;

    //Plant
    public bool IsPlanted = false;
    public bool isWater = false;
    public int waterTime;
    public float afterWatertime = 0;
    public float plantAnimTimer;

    //Animal
    public bool IsPeted = false;
    public bool isfeed = false;
    public int feedTime;
    public float afterFeedtime = 0;
    public float animalAnimTimer;

    public virtual void CallUpdate()
    {

    }

    public virtual void Collected()
    {

    }

    public virtual void UpdateInfo(InfoObject info)
    {

    }

    public virtual void OnSell() { }

    public virtual void CheckIsLocked()
    {
        
    }

    public virtual void IsBought(bool buy)
    {

    }

    public virtual void isWatering()
    {

    }
}
