using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimalItem : MonoBehaviour
{
    public Text text;
    public InfoObject animal;
    SFXManager sfx;
    CoopManager coop;

    void Awake()
    {
        sfx = GameObject.FindGameObjectWithTag("SFX").GetComponent<SFXManager>();
    }

    void Start()
    {
        coop = FindObjectOfType<CoopManager>();
    }

     private void Update()
    {
        if (Inventory.singleton.inventory.ContainsKey(animal.name) && text != null)
            text.text = Inventory.singleton.inventory[animal.name].ToString();
    }

    public void BuyAnimal()
    {
        if(Inventory.singleton.coin >= animal.price)
        {
            CoinManagement.singleton.AnimLosetrgigger();
            Inventory.singleton.coin -= animal.price;
            Inventory.singleton.AddSeedtoInventory(animal.name);

            Debug.Log("Buy :" + animal.ObjectName);

            sfx.PlaySFX(sfx.BuyPlant);
        }
        else
        {
            sfx.PlaySFX(sfx.NoMoney);
            Debug.Log("Not Enough Coin");
        }
    }

    public void ChooseAnimal()
    {
        if(Inventory.singleton.inventory.ContainsKey(animal.name))
        {
            if(Inventory.singleton.inventory[animal.name] >= 1)
            {
                if(PetManagement.singleton._tempAnimalStatus!= null)
                {
                Inventory.singleton.inventory[animal.name]--;
                coop.SelectAnimal(this);
                PetManagement.singleton.closePanel();
                PetManagement.singleton.tempAnimal();
                }
            }
          
        }
    }
}
