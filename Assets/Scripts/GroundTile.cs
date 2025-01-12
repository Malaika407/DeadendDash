using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner Spawner;

    public GameObject[] obstaclePrefabs; // Array to hold different obstacle prefabs

    private void Start()
    {
        Spawner = FindAnyObjectByType<GroundSpawner>();
        if (Spawner == null)
        {
            Debug.LogError("GroundSpawner not found in the scene!");
        }
        SpawnObstacles();
        spawnCoins();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure only the player triggers this
        {
            Debug.Log("Player exited tile. Spawning new tile.");
            Spawner.SpawnTile();
            Destroy(gameObject, 2);
        }
    }

    void SpawnObstacles()
    {
        int numberOfObstacles = Random.Range(0, 3); // Randomly choose how many obstacles to spawn

        for (int i = 0; i < numberOfObstacles; i++)
        {
            // Choose a random spawn index
            int obstacleSpawnIndex = Random.Range(2, 5);
            Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

            // Choose a random obstacle
            int randomObstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            GameObject chosenObstacle = obstaclePrefabs[randomObstacleIndex];

            // Spawn the obstacle
            Instantiate(chosenObstacle, spawnPoint.position, Quaternion.identity, transform);
        }
    }

    public GameObject coinsPrefab;

    void spawnCoins()
    {
        int cointToSpawn = 10;
        for (int i = 0; i < cointToSpawn; i++) {

            GameObject temp = Instantiate(coinsPrefab);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));

        if(point != collider.ClosestPoint(point))
        {
            point=GetRandomPointInCollider(collider);   
        }

        point.y = 1;
        return point;

    }


}
