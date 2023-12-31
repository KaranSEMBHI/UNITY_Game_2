using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Static instance variable to hold the singleton instance
    private static Spawner _instance;

    // Public property to access the singleton instance
    public static Spawner Instance => _instance;

    // The prefab to be spawned by the spawner
    public GameObject prefab;

    // The rate at which the prefabs are spawned
    public float spawnRate = 1f;

    // The minimum height at which the prefabs are spawned
    public float minHeight = -1f;

    // The maximum height at which the prefabs are spawned
    public float maxHeight = 1f;

    // Called when the script instance is being loaded
    private void Awake()
    {
        // Set the singleton instance
        _instance = this;
    }

    // Called every time the script instance is enabled
    private void OnEnable()
    {
        // Invoke the Spawn method repeatedly with the specified spawn rate
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    // Called every time the script instance is disabled
    private void OnDisable()
    {
        // Cancel the repeating invocation of the Spawn method
        CancelInvoke(nameof(Spawn));
    }

    // Method to spawn the prefabs
    private void Spawn()
    {
        // Instantiate a prefab at the spawner's position with no rotation
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);

        // Adjust the spawned prefab's position vertically within the specified range
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
