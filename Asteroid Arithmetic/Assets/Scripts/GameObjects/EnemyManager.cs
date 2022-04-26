using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    /// <summary>
    /// Game object reference
    /// </summary>
    public GameObject prefab;

    /// <summary>
    /// List of Asteroids
    /// </summary>
    private List<GameObject> gameObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAsteroidOnTime", 2f, 10f);
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
        // After Asteroid has spawned move across screen
        if (gameObjects is not null)
        {
            foreach (GameObject obj in gameObjects)
            {
                Vector3 tempVect = new Vector3(0, 0, 0);
                tempVect = tempVect.normalized * obj.GetComponent<EnemyController>().speed * Time.deltaTime;

                obj.GetComponent<EnemyController>().rigidbody2d.MovePosition(transform.position + tempVect);
            }
        }
    }

    /// <summary>
    /// Resets touch position after a touch
    /// </summary>
    private void SpawnAsteroidOnTime()
    {
        // Creates object at x=-4, y=3.1, z=0
        gameObjects.Add(Instantiate(prefab, transform.position, Quaternion.identity));
    }
}
