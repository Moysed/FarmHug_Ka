using Lean.Pool;
using UnityEngine;

public class EnemiesFollowing : MonoBehaviour
{
    PlantStatus _tempPlantStatus;
    public GameObject plant;
    public Animator animator;
    public bool Isend_ = true;
     public float speed = 0;
    public int hp;
    //[SerializeField] float timer;
    [SerializeField] public int leaveCheck = 0;
    float distance;
    public float floatingRadius = 200; // Radius within which the object will float
    public Vector2 Selfpos;
    private Vector2 initialPosition;
    private Vector2 MiddleofScreen;
    Vector3 spawnPosition;
    float side;
    bool isleft;
    bool isright;

    void Start()
    {
        
        animator = GetComponent<Animator>();
        MiddleofScreen = new Vector2(0, 0);
        //timer = 0;
        hp = 1;
        Selfpos = new Vector2(Random.Range(10, 20), Random.Range(10, 20));
        transform.position = Selfpos;
        UpSpeedCrow();
    }

    void Update()
    {
        UpSpeedCrow();
        if (hp < 0)
        {
            hp = 0;
        }

        if (Isend_)
        {

            plant = GameObject.FindGameObjectWithTag("Plant");
            Isend_ = false;
        }

        //Debug.Log(plant);


        if (plant != null)
        {
            if (plant.activeSelf)
            {
                if (plant.transform.position.x < transform.position.x)
                {

                    animator.SetBool("LeftDirection", true);
                    animator.SetBool("RightDirection", false);


                }

                if (plant.transform.position.x > transform.position.x)
                {

                    animator.SetBool("LeftDirection", false);
                    animator.SetBool("RightDirection", true);


                }
            }
            else if (!plant.activeSelf)
            {
                if (spawnPosition.x < transform.position.x)
                {
                    animator.SetBool("LeftDirection", true);
                    animator.SetBool("RightDirection", false);

                }
                else if (spawnPosition.x > transform.position.x)
                {
                    animator.SetBool("LeftDirection", false);
                    animator.SetBool("RightDirection", true);
                }
            }

            if (hp <= 0 && plant.activeSelf)
            {
                if (spawnPosition.x < transform.position.x)
                {
                    animator.SetBool("LeftDirection", true);
                    animator.SetBool("RightDirection", false);

                }
                else if (spawnPosition.x > transform.position.x)
                {
                    animator.SetBool("LeftDirection", false);
                    animator.SetBool("RightDirection", true);
                }
            }
            else if (hp <= 0 && !plant.activeSelf)
            {
                if (spawnPosition.x < transform.position.x)
                {
                    animator.SetBool("LeftDirection", true);
                    animator.SetBool("RightDirection", false);

                }
                else if (spawnPosition.x > transform.position.x)
                {
                    animator.SetBool("LeftDirection", false);
                    animator.SetBool("RightDirection", true);
                }
            }
        }
     

        /*if (hp <= 0)
        {
            plant = null;
            transform.position = Vector2.MoveTowards(transform.position, spawnPosition, speed * Time.deltaTime);
        }*/

        // ******** Enemy Behaviour *************** 
        if (plant != null && plant.activeSelf == true && hp > 0)
        {
            distance = Vector2.Distance(transform.position, plant.transform.position);
            Vector2 direction = plant.transform.position - transform.position;

            //Go to Plant
            transform.position = Vector2.MoveTowards(transform.position, plant.transform.position, speed * Time.deltaTime) ;
            RandPos();
        }
        if ((plant != null && plant.active == false) || hp <= 0)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, spawnPosition, speed * Time.deltaTime) ;
            RandPos();
        }
        if(plant == null)
        {
            transform.position = Vector2.MoveTowards(transform.position, spawnPosition, speed * Time.deltaTime);
            RandPos();

            if (spawnPosition.x < transform.position.x)
            {
                animator.SetBool("LeftDirection", true);
                animator.SetBool("RightDirection", false);

            }
            else if (spawnPosition.x > transform.position.x)
            {
                animator.SetBool("LeftDirection", false);
                animator.SetBool("RightDirection", true);
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CamEdge")
        {
            Debug.Log("Out of Edge");
            LeanPool.Despawn(gameObject);
            EnemySpawner.singleton.currentEnemyCount--;
            leaveCheck = 0;
            hp = 1;
            Isend_ = true;
        }

       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Scarecrow")
        {
            hp = 0;
            Debug.Log(hp);
        }

 if (collision.tag == "Plant")
        {
            if(hp > 0)
            {
                _tempPlantStatus = collision.GetComponentInParent<PlantStatus>(); 
                if(plant != null && plant.activeSelf)
                {
                    _tempPlantStatus.destroyPlantFromEnemy();
                    plant = default;
                    if(_tempPlantStatus.progressionbar.slider != null)
                    {
                       _tempPlantStatus.progressionbar.slider.value = 0;
                       _tempPlantStatus.progressBarBoarder.gameObject.SetActive(false);
                       if(_tempPlantStatus.wet.gameObject.activeSelf)
                       {
                            _tempPlantStatus.wet.gameObject.SetActive(false);
                       }
                    }

                }
            }
        }
    }

    void RandPos()
    {
        Camera mainCamera = Camera.main;

        // Define spawn position outside the screen based on camera viewport
        float spawnX = Random.Range(0f, 1f); // Random x position within the viewport
        float spawnY = Random.Range(0f, 1f); // Random y position within the viewport

        // Set spawn position based on random values
        spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(spawnX, spawnY, mainCamera.nearClipPlane));

        // Determine which side of the screen to spawn the enemy

        if (side < 0.25f) // Spawn on the left side
        {
            spawnPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(-0.5f, spawnY, mainCamera.nearClipPlane)).x;
        }
        else if (side < 0.5f) // Spawn on the right side
        {
            spawnPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(1.5f, spawnY, mainCamera.nearClipPlane)).x;
        }
        else if (side < 0.75f) // Spawn on the top side
        {
            spawnPosition.y = mainCamera.ViewportToWorldPoint(new Vector3(spawnX, 1.5f, mainCamera.nearClipPlane)).y;
        }
        else // Spawn on the bottom side
        {
            spawnPosition.y = mainCamera.ViewportToWorldPoint(new Vector3(spawnX, -0.5f, mainCamera.nearClipPlane)).y;
        }
    }

    void UpSpeedCrow()
    {
        if(GroundMangement.singleton.countUnlockGround <= 4){
            speed = 2;
        }
        if (GroundMangement.singleton.countUnlockGround > 4 &&GroundMangement.singleton.countUnlockGround <= 8 )
        {
            
            //speed = Random.Range(2,3.5f);
            speed = 3;
        }
        if (GroundMangement.singleton.countUnlockGround > 8 &&GroundMangement.singleton.countUnlockGround <= 12 )
        {
            hp = 2; 
            //speed = Random.Range(2,4.5f);
            speed = 4.5f;
        }
        if (GroundMangement.singleton.countUnlockGround > 12 &&GroundMangement.singleton.countUnlockGround <= 16 )
        {
            hp = 2;
            //speed = Random.Range(2,6f);
            speed = 6;
        }
        
    }
}
