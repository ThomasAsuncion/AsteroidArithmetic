using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy controller script
/// </summary>
public class EnemyController : MonoBehaviour
{
    /// <summary>
    /// Number assigned to Asteroid for equation
    /// </summary>
    public int number;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SpawnAsteroid();
    }

    /// <summary>
    /// Spawn asteroids into the world
    /// </summary>
    private void SpawnAsteroid()
    {
        StartCoroutine(SpawnAsteroidOnTime());
    }

    /// <summary>
    /// Resets touch position after a touch
    /// </summary>
    IEnumerator SpawnAsteroidOnTime()
    {
        yield return new WaitForSeconds(2f);
        transform.position = new Vector3(-4f, 3.1f, 0f);
    }
}