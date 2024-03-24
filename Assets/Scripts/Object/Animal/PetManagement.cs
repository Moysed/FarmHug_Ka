using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class PetManagement : MonoBehaviour
{

    [SerializeField] RectTransform storePanelRect;
    [SerializeField] float topPosY, middlePosY;
    [SerializeField] float tweenDuration;

    public static PetManagement singleton;

    public GameObject storePanel;
    //public GameObject seedPanel;

    AnimalStatus[] status;

    public Inventory inventory;

    public CoopManager cm;

    public InfoObject selectedAnimal;

    public BaseStatus _tempAnimalStatus;

    public float timer;
    

    void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        status = this.GetComponentsInChildren<AnimalStatus>();
        inventory = FindObjectOfType<Inventory>();

        //if(_tempAnimalStatus.isLock == true)
        //{
            //Inventory.singleton.coin -= ;
            //seedPanel.SetActive(false);
            storePanel.SetActive(false);
        //    Debug.Log(_tempAnimalStatus.isLock);
        //}
        //storePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_tempAnimalStatus == null)
        {
            cm.isPeting = false;
        }
    }


    public void IsPeted(BaseStatus _objBase)
    {

        _tempAnimalStatus = (BaseStatus)_objBase;

        if(_tempAnimalStatus == null)
        {
            Debug.Log(_tempAnimalStatus);
            return;
        }

        Debug.Log(_tempAnimalStatus);
        if (!cm.isPeting && _tempAnimalStatus.isLock == false)
        {
            if (_tempAnimalStatus.ObjectStage == 0)
            {
                //Debug.Log(_tempPlantStatus.isLock);
                storePanel.SetActive(true);
                storePanelIntro();
                
            }
            //Debug.Log(_tempAnimalStatus.isLock);
            //storePanel.SetActive(true);
            //storePanelIntro();
        }

     

        if (_tempAnimalStatus.IsPeted)
        {
            storePanel.SetActive(false );
            closePanel();
            if (_tempAnimalStatus.ObjectStage >= selectedAnimal.ObjectStages.Length)
            {
                _tempAnimalStatus.Collected();
                _tempAnimalStatus.collectCheck = true;
               
            }
        }
    }
    public async void closePanel()
    {
        await storePanelOuttro();
        storePanel.SetActive(false);
        //seedPanel.SetActive(false);
    }

    public void tempAnimal()
    {
        _tempAnimalStatus.UpdateInfo(cm.selectAnimal.animal);
        _tempAnimalStatus = null;
    }

    void storePanelIntro()
    {
        //seedPanel.SetActive(false);
        storePanelRect.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
    }

    async Task storePanelOuttro()
    {
        await storePanelRect.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
    }
}