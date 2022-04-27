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

    /// <summary>
    /// Speed of Asteroid flying across screen
    /// </summary>
    public float speed;

    /// <summary>
    /// Rigidbody reference for moving asteroids
    /// </summary>
    private Rigidbody2D rigidbody2D;

    /// <summary>
    /// Screen bounds for scene based on camera location
    /// </summary>
    private Vector2 screenBounds;

    /// <summary>
    /// Array of sprites that will randomly pull to assign
    /// </summary>
    public Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        // Find Rigidbody and move asteroid at a constant rate
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(speed, 0);

        // Randomly assign sprite to it when it spawns in game
        GetComponent<SpriteRenderer>().sprite = spriteArray[Random.Range(0, spriteArray.Length)];


        number = Random.Range(0, 20);

        // Setup screen bounds for game
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}