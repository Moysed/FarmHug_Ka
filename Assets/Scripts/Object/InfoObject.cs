using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Plant", menuName ="Plant")]
public class InfoObject : ScriptableObject
{
    public string ObjectName;
    public Sprite[] ObjectStages;
    public float timeBtwstage = 2f;
    public int price;

    public float _growthTime;
    //public int sellPrice;
}
