using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    SFXManager sfx;
    public PlantItem selectPlant;
    public bool isPlanting = false;

    public CoinManagement coin;
    
    private Inventory inventory;

    public InfoObject plant;

    void Awake()
    {
        sfx = GameObject.FindGameObjectWithTag("SFX").GetComponent<SFXManager>();
    }

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void SelectPlant(PlantItem newPlant)
    {
            selectPlant = newPlant;
            if(selectPlant != null)
            {
                isPlanting = true;
                //inventory.coin -= selectPlant.plant.price;
            }
            else
            {
                isPlanting = false;
            }
            coin.UpdateCoin(inventory.coin);
            
            //SFXPlaying.singleton.PlayPlant();
            //sfx.PlaySFX(sfx.Plant);

    }
}
