using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class TouchIdentifier : MonoBehaviour
{
    public int fingerId;
    public float timeCreated;
    public Vector2 startPosition;
    public Vector3 deltaPosition;
    float _time;
    public TouchDetector t;
    SFXManager sfx;

    private void Start()
    {
        t = FindObjectOfType<TouchDetector>();
        sfx = GameObject.FindGameObjectWithTag("SFX").GetComponent<SFXManager>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            BaseStatus _tempStatus = collision.GetComponent<BaseStatus>();
            PlantStatus _tempPlantStatus = collision.GetComponent<PlantStatus>();
            if( PlayerScript.singleton.onAnimrun == false)
            {
                GroundMangement.singleton.Isplanted(_tempStatus);
            }
               
            
            if(_tempPlantStatus.isLock == true)
            {
                _tempPlantStatus.ShowDecisionPanel();
            }
        }

        if(collision.tag == "ANimalContainer")
        {
            BaseStatus _tempStatus = collision.GetComponent<BaseStatus>();
            AnimalStatus _tempAnimalStatus = collision.GetComponent<AnimalStatus>();

            if (_tempStatus == null)
                _tempStatus = collision.GetComponentInParent<BaseStatus>();

                if(_tempAnimalStatus.isLock == true)
                {
                    _tempAnimalStatus.ShowDecisionPanel();
                }
                if(_tempAnimalStatus.isLock == false)
                {
                    PetManagement.singleton.IsPeted(_tempStatus);
                }
        }

        if (collision.tag == "Animal")
        {
            BaseStatus status = collision.GetComponentInParent<BaseStatus>();

            Debug.Log(status);
            if (status.collectCheck == true)
            {
                
                    PetManagement.singleton._tempAnimalStatus.Collected();
                
                
                status.collectCheck = false;
            }
        }

        if (collision.tag == "Plant")
        {
            BaseStatus status = collision.GetComponentInParent<BaseStatus>();

            if (status.collectCheck)
            {
                if(PlayerScript.singleton.onAnimrun == false)
                {
                        GroundMangement.singleton._tempPlantStatus.Collected();
                }
                status.collectCheck = false;
            }
        }

        if (collision.tag == "enemy")
        {
            EnemiesFollowing enemy = collision.GetComponent<EnemiesFollowing>();
            enemy.hp--;

            if (enemy.hp < 0)
            {
                enemy.hp = 0;
            }

            Debug.Log(enemy.hp);
        }

        if (collision.tag == "Status")
        {
            BaseStatus _tempStatus = collision.GetComponent<BaseStatus>();
            AnimalStatus _tempAnimalStatus = collision.GetComponent<AnimalStatus>();

            if (_tempStatus == null)
                _tempStatus = collision.GetComponentInParent<BaseStatus>();
            
                     _tempStatus.isWatering();
                
        }

        if (collision.tag == "PlantStatus")
        {
            BaseStatus _tempStatus = collision.GetComponent<BaseStatus>();
            PlantStatus _tempPlantStatus = collision.GetComponent<PlantStatus>();

            if (_tempStatus == null)
                _tempStatus = collision.GetComponentInParent<BaseStatus>();
            if (PlayerScript.singleton.onAnimrun == false)
            {
                _tempStatus.isWatering();
            }
        }

        /*if (collision.tag == "Credit")
        {
            sfx.PlaySFX(sfx.Click);
            Debug.Log("credit");
            Credit.singleton.unShow();
        }*/
    }
}
