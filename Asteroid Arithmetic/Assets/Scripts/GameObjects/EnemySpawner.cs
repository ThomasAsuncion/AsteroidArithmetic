using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /// <summary>
    /// Prefab for game object being used
    /// </summary>
    public GameObject enemyPrefab;

    /// <summary>
    /// Time between each spawn of an asteroid
    /// </summary>
    public float respawnTime = 1.0f;

    /// <summary>
    /// Screen bounds for scene based on camera location
    /// </summary>
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        // Setup screen bounds for game
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(TimeSpawn());
    }

    /// <summary>
    /// Spawn enemy in fixed locations
    /// </summary>
    private void SpawnEnemy()
    {
        GameObject gameObject = Instantiate(enemyPrefab) as GameObject;

        // Sets up where the asteroid will spawn - only spawns left of the screen moving right and only from half the screen upwards on y-axis
        gameObject.transform.position = new Vector2(screenBounds.x * -2f, Random.Range(1, screenBounds.y - 1));
    }

    /// <summary>
    /// Waits to spawn an enemy based on the respawn time
    /// </summary>
    IEnumerator TimeSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }
}
