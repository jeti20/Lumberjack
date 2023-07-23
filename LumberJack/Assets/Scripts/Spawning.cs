using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject[] itemPrefabs; // Array of item prefabs to spawn
    public Transform spawnLocation; // The spawn location for the items

    private GameObject spawnedItem; // Reference to the currently spawned item

    public void SpawnRandomItem()
    {
        // Check if there is already a spawned item
        if (spawnedItem != null)
        {
            Destroy(spawnedItem); // Destroy the previously spawned item
        }

        // Generate a random index within the range of the itemPrefabs array
        int randomIndex = Random.Range(0, itemPrefabs.Length);

        // Instantiate the random item prefab at the spawn location
        spawnedItem = Instantiate(itemPrefabs[randomIndex], spawnLocation.position, Quaternion.identity);

        // Optionally, you can modify or access the spawned item here
    }

    // Example usage in another script or Unity event
    void Start()
    {
        SpawnRandomItem();
    }

    // Example usage to respawn item when it gets destroyed
    void Update()
    {
        if (spawnedItem == null)
        {
            SpawnRandomItem();
        }
    }
}
