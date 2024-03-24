using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public TextMeshProUGUI strawberry;
    public TextMeshProUGUI onion;
    public TextMeshProUGUI mandrake;
    public TextMeshProUGUI pumpkin;

    public static Inventory singleton;
    public Dictionary<string, int> inventory = new Dictionary<string, int>(); // Use a dictionary to store product types and quantities
    private CoinManagement coinManager;
    public SellManager autoSell;
    private CoopManager cm;
    private FarmManager fm;
    public int coin = 100;
    int[] sellPrice;
    int totalIncome;
 
    private void Awake()
    {
        singleton = this;
        //sfx = GameObject.FindGameObjectWithTag("SFX").GetComponent<SFXManager>();
    }
    
    void Start()
    {
        cm = FindObjectOfType<CoopManager>();
        fm = FindObjectOfType<FarmManager>();
        autoSell = GetComponent<SellManager>();
        sellPrice = new int[5];
    }
 
    void Update()
    {
        CoinManagement.singleton.UpdateCoin(coin);
            
           
            
        //sellTime -= Time.deltaTime;
 
        if (coin <= 0)
        {
            coin = 0;
        }
 
        autoSell.AutoSell();
         strawberry.text = GetPlantQuantity("Strawberry").ToString();
            onion.text = GetPlantQuantity("Onion").ToString();
            pumpkin.text = GetPlantQuantity("Pumpkin").ToString();
            mandrake.text = GetPlantQuantity("Mandrake").ToString();
    }
 
    // Add a plant to the inventory
    public void AddToInventory(string productType)
    {
        if (inventory.ContainsKey(productType))
        {
            inventory[productType]++;
        }
        else
        {
            inventory.Add(productType, 1);
        }
 
        Debug.Log("Added " + productType + " to inventory. Total: " + inventory[productType]);
    }
 
    public void AddSeedtoInventory(string seedType)
    {
        if (inventory.ContainsKey(seedType))
        {
            inventory[seedType]++;
        }
        else
        {
            inventory.Add(seedType, 1);
        }
        Debug.Log("Bought " + seedType + " to inventory. Total: " + inventory[seedType]);
    }
 
    // Sell a specific amount of a product type from the inventory
    public void SellFromInventory(string productType, int amount)
    {
        CoinManagement.singleton.AnimGetmoneytrgigger();
        if (inventory.ContainsKey(productType))
        {
            if (inventory[productType] >= amount)
            {
                if(productType == "Mandrake" && amount != 0 && inventory[productType] != 0)
                {
                    Debug.Log("Sold " + amount + " " + productType + "(s) from inventory. Remaining: " + inventory[productType]);
                    coin += 400 * inventory[productType];
                    totalIncome += 400 * inventory[productType];
                    inventory[productType] = 0;
                    amount = 0;
                }
                /*if (productType == "Cow" && amount != 0 && inventory[productType] != 0)
                {
                    Debug.Log("Sold " + amount + " " + productType + "(s) from inventory. Remaining: " + inventory[productType]);
                    coin += 0 * inventory[productType];
                    totalIncome += 2 * inventory[productType];
                    inventory[productType] = 0;
                    amount = 0;
 
                }
                if (productType == "Pig" && amount != 0 && inventory[productType] != 0)
                {
                    Debug.Log("Sold " + amount + " " + productType + "(s) from inventory. Remaining: " + inventory[productType]);
                    coin += 8 * inventory[productType];
                    totalIncome += 8 * inventory[productType];
                    inventory[productType] = 0;
                    amount = 0;
                }
                if (productType == "Chicken" && amount != 0 && inventory[productType] != 0)
                {
                    Debug.Log("Sold " + amount + " " + productType + "(s) from inventory. Remaining: " + inventory[productType]);
                    coin += 2 * inventory[productType];
                    totalIncome += 2 * inventory[productType];
                    inventory[productType] = 0;
                    amount = 0;
                }*/
                if (productType == "Strawberry" && amount != 0 && inventory[productType] != 0)
                {
                    Debug.Log("Sold " + amount + " " + productType + "(s) from inventory. Remaining: " + inventory[productType]);
                    coin += 50 * inventory[productType];
                    totalIncome += 50 * inventory[productType];
                    inventory[productType] = 0;
                    amount = 0;
 
                }
                if (productType == "Onion" && amount != 0 && inventory[productType] != 0)
                {
                    Debug.Log("Sold " + amount + " " + productType + "(s) from inventory. Remaining: " + inventory[productType]);
                    coin += 70 * inventory[productType];
                    totalIncome += 70 * inventory[productType];
                    inventory[productType] = 0;
                    amount = 0;
 
                }
                if (productType == "Pumpkin" && amount != 0 && inventory[productType] != 0)
                {
                    Debug.Log("Sold " + amount + " " + productType + "(s) from inventory. Remaining: " + inventory[productType]);
                    coin += 90 * inventory[productType];
                    totalIncome += 90 * inventory[productType];
                    inventory[productType] = 0;
                    amount = 0;
 
                }
                Debug.Log("Total income: " + totalIncome + ", Total coin: " + coin);
                totalIncome = 0;

 
            }
                    else
                    {
                        Debug.Log("Not enough " + productType + " in inventory to sell.");
                    }
                }
                else
                {
                    Debug.Log("Plant type " + productType + " not found in inventory.");
                }
            }

 
    // Get the quantity of a specific product type in the inventory
    public int GetPlantQuantity(string productType)
    {
        if (inventory.ContainsKey(productType))
        {
            return inventory[productType];
        }
        else
        {
            return 0;
        }
    }
}
