using UnityEngine;

public class Spawnable : MonoBehaviour
{

    [SerializeField] private GameObject toSpawn;
    [SerializeField] private GameObject spawnIn;
    
    public float spawnRate = 1.0f;
    public int maxSpawns = 20;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            if (GameObject.FindGameObjectsWithTag(toSpawn.tag).Length < maxSpawns)
            {
                SpawnCollectible();
                timer = 0f;
            }
        }
    }

    void SpawnCollectible()
    {
        // Choose a random spawn region
        GameObject[] spawnRegions = GameObject.FindGameObjectsWithTag(spawnIn.tag);
        GameObject randomRegion = spawnRegions[Random.Range(0, spawnRegions.Length)];

        // Get a random point within the spawn region's collider
        Collider2D spawnCollider = randomRegion.GetComponent<Collider2D>();
        Vector2 spawnPoint = RandomPointInBounds(spawnCollider.bounds);

        // Instantiate the collectible at the spawn point
        Instantiate(toSpawn, spawnPoint, Quaternion.identity);
    }

    Vector2 RandomPointInBounds(Bounds bounds)
    {
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );
    }
}
