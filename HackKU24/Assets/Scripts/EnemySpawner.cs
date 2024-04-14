using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject toSpawn;
    [SerializeField] private GameObject spawnIn;
    [SerializeField] private GameObject[] regions;

    public float spawnRate =  5.0f;
    public float regionSpawnDuration = 15.0f;
    private float timer;
    private float regionTimer;
    private int regionIndex = 0;

    void Start()
    {
        regions = GameObject.FindGameObjectsWithTag(spawnIn.tag);
    }

    void Update()
    {
        timer += Time.deltaTime;
        regionTimer += Time.deltaTime;

        if (regionTimer >= regionSpawnDuration)
        {
            regionIndex = (regionIndex + 1) % regions.Length;
            regionTimer = 0f;
        }

        if (timer >= spawnRate)
        {
            SpawnCollectible();
            timer = -0.5f;
        }
    }

    public void SpawnCollectible()
    {
        // Get current spawn region
        GameObject region = regions[regionIndex];

        // Get a random point within the spawn region's collider
        Collider2D spawnCollider = region.GetComponent<Collider2D>();
        Vector2 spawnPoint = RandomPointInBounds(spawnCollider.bounds);

        // Instantiate the collectible at the spawn point
        GameObject spawnedCollectible = Instantiate(toSpawn, spawnPoint, Quaternion.identity);

        // Find all Goblin objects within the spawn region
        Collider2D[] colliders = Physics2D.OverlapBoxAll(spawnPoint, spawnCollider.bounds.size, 0f);
        List<GameObject> goblinsInRegion = new List<GameObject>();
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Goblin"))
            {
                goblinsInRegion.Add(collider.gameObject);
            }
        }

        // Move the enemy to a random Goblin within the region
        if (goblinsInRegion.Count > 0)
        {
            GameObject randomGoblin = goblinsInRegion[Random.Range(0, goblinsInRegion.Count)];
            EnemyMovement enemyMovement = spawnedCollectible.GetComponent<EnemyMovement>();
            enemyMovement.target = randomGoblin.transform;
        }

    }

    Vector2 RandomPointInBounds(Bounds bounds)
    {
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );
    }
}
