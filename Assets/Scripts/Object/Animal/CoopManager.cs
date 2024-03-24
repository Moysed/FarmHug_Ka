using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoopManager : MonoBehaviour
{
    SFXManager sfx;
    public AnimalItem selectAnimal;
    public bool isPeting = false;

    public CoinManagement coin;
    
    public InfoObject animal;
    private Inventory inventory;

    void Awake()
    {
        sfx = GameObject.FindGameObjectWithTag("SFX").GetComponent<SFXManager>();
    }

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void SelectAnimal(AnimalItem newAnimal)
    {
        
            selectAnimal = newAnimal;
        Debug.Log(selectAnimal.name);
            if(inventory.coin >= selectAnimal.animal.price)
            {
                isPeting = true;
                //inventory.coin -= selectAnimal.animal.price;
            }
            else
            {
                isPeting = false;
            }
            coin.UpdateCoin(inventory.coin);

            sfx.PlaySFX(sfx.Plant);
/*
            if(selectAnimal.animal.ObjectName == "Pig")
            {
                SFXPlaying.singleton.PlayPig();
            }
            else if(selectAnimal.animal.ObjectName == "Cow")
            {
                SFXPlaying.singleton.PlayCow();
            }
            else if(selectAnimal.animal.ObjectName == "Chicken")
            {
                SFXPlaying.singleton.PlayDuck();
            }
*/ 
    }
}
