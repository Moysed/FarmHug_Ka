using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner singleton;
    public GameObject _plant;
    public GameObject enemyPrefab;
    public float spawnInterval;
    public float spawnRadius = 5f;
    public int maxEnemyCount = 1; // Maximum number of enemies allowed

    SFXManager sfx;

    [SerializeField]
    public float spawnTimer;
    public int currentEnemyCount = 0;

    void Awake()
    {
        singleton = this;
        sfx = GameObject.FindGameObjectWithTag("SFX").GetComponent<SFXManager>();
    }

    // Start is called before the first frame update
    void Start()
    { 
        spawnInterval = 20;
        spawnTimer = spawnInterval; 
    }

    // Update is called once per frame
    void Update()
    { 
        _plant = GameObject.FindWithTag("Plant");
        
        if (_plant != null && _plant.activeSelf)
        {
            spawnTimer -= Time.deltaTime;

            // If the spawn timer reaches zero or less and current enemy count is less than maximum
            if (spawnTimer <= 0 && currentEnemyCount < maxEnemyCount && GroundMangement.singleton.countUnlockGround >= 3)
            {
                // Spawn a new enemy
                SpawnEnemy();
            }

            if (spawnTimer < 0)
            {
                // Reset the spawn timer
                spawnInterval = Random.Range(20,50);
                spawnTimer = spawnInterval;
            }
        }
    }

    void SpawnEnemy()
    {
        // Get the main camera
        Camera mainCamera = Camera.main;

        // Define spawn position outside the screen based on camera viewport
        float spawnX = Random.Range(0f, 1f); // Random x position within the viewport
        float spawnY = Random.Range(0f, 1f); // Random y position within the viewport

        // Set spawn position based on random values
        Vector3 spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(spawnX, spawnY, mainCamera.nearClipPlane));

        // Determine which side of the screen to spawn the enemy
        float side = Random.Range(0f, 1f); // Random value to determine side of the screen
        if (side < 0.25f) // Spawn on the left side
        {
            spawnPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(0f, spawnY, mainCamera.nearClipPlane)).x;
        }
        else if (side < 0.5f) // Spawn on the right side
        {
            spawnPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(1f, spawnY, mainCamera.nearClipPlane)).x;
        }
        else if (side < 0.75f) // Spawn on the top side
        {
            spawnPosition.y = mainCamera.ViewportToWorldPoint(new Vector3(spawnX, 1f, mainCamera.nearClipPlane)).y;
        }
        else // Spawn on the bottom side
        {
            spawnPosition.y = mainCamera.ViewportToWorldPoint(new Vector3(spawnX, 0f, mainCamera.nearClipPlane)).y;
        }

        // Spawn enemy using LeanPool
        GameObject newEnemy = LeanPool.Spawn(enemyPrefab, spawnPosition, Quaternion.identity);
        //LeanPool.Links.Count
        // Increment current enemy count
        currentEnemyCount++;
        sfx.PlaySFX(sfx.Crow);
    }
}