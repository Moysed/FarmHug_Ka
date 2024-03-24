using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public AnimalStatus _ownerAnimalObjectPrefabs;
    Inventory inventory;

    public enum InstanceMode
    {
        Instance,
        Pool
    }

    public InstanceMode instanceMode = InstanceMode.Pool;
}
