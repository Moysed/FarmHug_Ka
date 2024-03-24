using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlantStatus : BaseStatus
{
    public GameObject progressBarBoarder;
    public TextMeshProUGUI priceTextDecision;
    public TextMeshProUGUI priceText;
    public GameObject DecisionPanel;
    public GameObject bar;
    public GameObject _player;
    SFXManager sfx;
    public SpriteRenderer ground_;
    public SpriteRenderer sign;
    public SpriteRenderer wet;
    public GameObject FloatingTextPrefab;
    EnemiesFollowing enemy;
    public int _spacePrice;
    public GameObject StatusPrefab;
    GroundMangement gm;
    public SpriteRenderer plant;
    [SerializeField]
    BoxCollider2D plantCollider;
    [SerializeField]
    public FloatingBar progressionbar;
 
 
    Vector3 spawnplayerpos;
    public enum InstanceMode
    {
        Instance,
        Pool
    }
    void Awake()
    {
        sfx = GameObject.FindGameObjectWithTag("SFX").GetComponent<SFXManager>();
    }

    public InstanceMode instanceMode = InstanceMode.Pool;
    void Start()
    {
        bar.SetActive(false);
        spawnplayerpos = this.transform.position;
        gm = GroundMangement.singleton;
        enemy = GetComponent<EnemiesFollowing>();
        waterTime = 0; // Adjust the initial grow time as needed
        priceText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        priceText.text = _spacePrice.ToString();
        priceTextDecision.text = _spacePrice.ToString();
        progressionbar = GetComponentInChildren<FloatingBar>();
        //water Time
        if (progressionbar != null)
        {
            if (plant.gameObject.active == false)
            {
                progressionbar.slider.value = 0;
            }
        }
        if (isSelected)
        {
            
            ground_.color = Color.yellow / 0.5f ;
        }
        if (!isSelected)
        {
            ground_.color = Color.white;
        }
 
        if (IsPlanted == false)
        {
            waterTime = 0;
        }
 
        if(IsPlanted == true)
        {
            isSelected = false;
            afterWatertime -= Time.deltaTime;
            plantAnimTimer -= Time.deltaTime;
            //progressBarBoarder.SetActive(true);
            if (waterTime >= 0 && waterTime <= 600)
            {
                if (afterWatertime <= 0)
                {
                    waterTime++;
                }
            }

            if (isWater == true)
            {
                if (progressionbar != null)
                {
                    progressionbar.slider.maxValue = _selfObjectInfo._growthTime;
                }
                wet.gameObject.SetActive(true);
                if(afterWatertime <= 0)
                {

                    if (plantAnimTimer <= 0)
                    {
                        if (ObjectStage >= _selfObjectInfo.ObjectStages.Length)
                        {
                            isSelected = false;
                            ObjectStage = _selfObjectInfo.ObjectStages.Length;
                        }
                        if (ObjectStage < _selfObjectInfo.ObjectStages.Length)
                        {
                            isSelected = false;
                            ObjectStage++;
                            UpdatePlant();
                        }
 
                        if (ObjectStage > _selfObjectInfo.ObjectStages.Length - 2)
                        {
 
                            collectCheck = true;
                        }
                        afterWatertime = 5;
 
                        if(progressionbar !=  null)
                        progressionbar.slider.value += _selfObjectInfo.timeBtwstage;
                        plantAnimTimer = _selfObjectInfo.timeBtwstage;
                    }
                }
            }
            
            if (ObjectStage > 0)
            {
                wet.gameObject.SetActive(false);
            }
 
            if(ObjectStage == 2)
            {
                if(progressionbar != null)
                progressionbar.slider.value = 0;
                bar.gameObject.SetActive(false);
            }
        }

        if(gm.selectedPlant != null)
        {
            if (ObjectStage == gm.selectedPlant.ObjectStages.Length - 1)
            {
                waterTime = 0;
            }
        }

        if (waterTime == 600 && plant.gameObject.activeSelf && isWater == false)
        {
            Debug.Log("Watering");
            ShowStatus();
        }
        else if(waterTime > 600)
        {
            waterTime = 601;
        }

        if(plant.gameObject.activeSelf == false && IsPlanted == true)
        {
            IsPlanted = false;
            destroyStatus();
        }

        if (gm.inventory.autoSell.sellTime == 0)
        {
            if(_selfObjectInfo != null)
            gm.inventory.SellFromInventory(_selfObjectInfo.ObjectName, gm.inventory.GetPlantQuantity(_selfObjectInfo.ObjectName));
        }
    }
    void ShowStatus()
    {
        StatusPrefab.SetActive(true);
    }
    void destroyStatus()
    {
        StatusPrefab.SetActive(false);
    }
    // Single Game Object
    public override void UpdateInfo(InfoObject newPlant)
    {
        IsPlanted = true;
        _selfObjectInfo = newPlant;
        gm.selectedPlant = newPlant;
        ObjectStage = 0;
        ObjectName = newPlant.name;

 
        UpdatePlant();
        plant.gameObject.SetActive(true);

    }
    public override void Collected()
    {
        PlayerScript.singleton.onAnimrun = true;
        Debug.Log("Harvested");
        IsPlanted = false;
        gm.fm.isPlanting = false;
        ObjectStage = 0;
        isWater = false;
        progressBarBoarder.SetActive(false);
        gm.inventory.AddToInventory(_selfObjectInfo.ObjectName);
        sfx.PlaySFX(sfx.Harvest);
        if (collectCheck)
        {
            if (PlayerScript.singleton.onAnimrun == true)
            {
                
                _player.transform.localPosition = new Vector3(spawnplayerpos.x,spawnplayerpos.y + 1.5f);
                PlayerScript.singleton.ChangeAnimationstate("IsHarvestLeft", "Isidle");
            }
            Invoke("resetHavestAnim", 0.5f);
        }
    }

    // Single Game object
    void UpdatePlant()
    {
        if(ObjectStage < _selfObjectInfo.ObjectStages.Length)
        {
            plant.sprite = _selfObjectInfo.ObjectStages[ObjectStage];
            plantCollider.size = plant.sprite.bounds.size;
            plantCollider.offset = new Vector2(0, plant.size.y /10);
        }
    }
    GameObject InstantiateObject(GameObject obj)
    {
            return Lean.Pool.LeanPool.Spawn(obj);
    }

    public override void CheckIsLocked()
    {
        if(Inventory.singleton.coin < _spacePrice && !isBought)
        {
            isLock = true;
            IsBought(isLock);
        }
        else if(Inventory.singleton.coin >= _spacePrice)
        {
            isSelected = true;
            isLock = false;
            IsBought(isLock);
        }
        if(isBought == true)
        {
            isLock = false;
        }
    }
    public override void IsBought(bool b)
    {
        if (!b && isBought == false)
        {
            CoinManagement.singleton.AnimLosetrgigger();
            
            Inventory.singleton.coin -= _spacePrice;
            isBought = true;
            sign.gameObject.SetActive(false);
            if (FloatingTextPrefab)
            {
                ShowFloatingText(" - "+ _spacePrice);
            }
            GroundMangement.singleton.countUnlockGround += 1;
            Debug.Log("Count Unlock Ground : " + GroundMangement.singleton.countUnlockGround);
            gm.seedPanel.SetActive(true);
            sfx.PlaySFX(sfx.BuyGround);
        }
        else if (isBought)
        {
            Debug.Log("Already bought");
        }
        else
        {
            ShowFloatingText(" Not Enough Money ");
            sfx.PlaySFX(sfx.NoMoney);
            Debug.Log("Not enough coin");
        }
    }
    void ShowFloatingText(string text)
    {
        var go = Instantiate(FloatingTextPrefab , transform.position, Quaternion.identity);
        go.GetComponent<TextMeshPro>().text = text;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    public void destroyPlantFromEnemy()
    {
        Debug.Log("Eated");
        IsPlanted = false;
        gm.fm.isPlanting = false;
        ObjectStage = 0;
        isWater = false;
        StatusPrefab.SetActive(false);
        plant.gameObject.SetActive(false);
        progressionbar.slider.value = 0;
    }
    public override void isWatering()
    {
        PlayerScript.singleton.onAnimrun = true;
        afterWatertime = 5;
        isWater = true;
        sfx.PlaySFX(sfx.Watering);
        waterTime = 0; // Reset grow time
        StatusPrefab.SetActive(false);
        progressBarBoarder.SetActive(true);
        if(isWater)
        {
        if (PlayerScript.singleton.onAnimrun == true)
        {
            _player.transform.localPosition = new Vector3(spawnplayerpos.x,spawnplayerpos.y + 1.5f);
            PlayerScript.singleton.ChangeAnimationstate("IsWateringLeft", "Isidle");
            Invoke("resetWateringAnim", 1.5f);
        }
        }
    }
    void resetWateringAnim()
    {
        if (PlayerScript.singleton.onAnimrun == true)
        {
            PlayerScript.singleton.ChangeAnimationstate("Isidle", "IsWateringLeft");
            PlayerScript.singleton.onAnimrun = false;
        }
        _player.transform.localPosition = PlayerScript.singleton.Spawnpos;
        bar.SetActive(true);
    }
    public void resetHavestAnim()
    {
        if (PlayerScript.singleton.onAnimrun == true)
        {
            PlayerScript.singleton.ChangeAnimationstate("Isidle", "IsHarvestLeft");
            
        }
        plant.gameObject.SetActive(false);

        //PlayerScript.singleton.onAnimrun = false;
        //resetPlayerPos();
        
        _player.transform.localPosition = PlayerScript.singleton.Spawnpos;
        PlayerScript.singleton.onAnimrun = false;
        isSelected = false;
    }

    public void ShowDecisionPanel()
    {
        DecisionPanel.gameObject.SetActive(true);
    }

    public void HideDecisionPanel()
    {
        DecisionPanel.SetActive(false);
    }
 
    /*void resetPlayerPos()
    {
        if(PlayerScript.singleton.onAnimrun == false)
        {
            _player.transform.localPosition = PlayerScript.singleton.Spawnpos;
            Debug.Log("on anim : " + PlayerScript.singleton.onAnimrun);
        }
    }*/
}