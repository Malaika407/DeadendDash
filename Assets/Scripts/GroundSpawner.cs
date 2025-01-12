using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile; // Reference to the ground tile prefab
    Vector3 nextSpawPoint; // Position for the next tile spawn

    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawPoint, Quaternion.identity);
        Debug.Log($"Spawned tile at: {nextSpawPoint}");
        nextSpawPoint = temp.transform.GetChild(1).transform.position;
    }

    void Start()
    {
        nextSpawPoint = groundTile.transform.position;
        for (int i = 0; i < 9; i++)
        {
            SpawnTile();
        }
    }
}
