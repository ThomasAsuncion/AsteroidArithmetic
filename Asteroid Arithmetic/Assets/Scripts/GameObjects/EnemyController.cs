using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    /// Reference to text on GUI
    /// </summary>
    public TextMeshProUGUI displayNumber;

    /// <summary>
    /// Speed of Asteroid flying across screen
    /// </summary>
    public float speed;

    /// <summary>
    /// Speed of which the object is rotating around the z-axis
    /// </summary>
    public float rotationsPerMinute = 10;

    /// <summary>
    /// Position in which the asteroid will start rotating
    /// </summary>
    private float positionZToRotate = 0f;

    /// <summary>
    /// Rigidbody reference for moving asteroids
    /// </summary>
    private new Rigidbody2D rigidbody2D;

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
        // Intialize text
        displayNumber = FindObjectOfType<TextMeshProUGUI>();

        // Find Rigidbody and move asteroid at a constant rate
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(speed, 0);

        // Randomly assign sprite to it when it spawns in game
        GetComponent<SpriteRenderer>().sprite = spriteArray[Random.Range(0, spriteArray.Length)];


        number = Random.Range(0, 20);

        // Setup screen bounds for game
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Sets the intial position to begin rotation
        positionZToRotate = Random.Range(-2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        displayNumber.text = number.ToString();

        transform.Rotate(0, 0,  positionZToRotate * rotationsPerMinute * Time.deltaTime);

        DestroyObjectOffScreen();
    }

    /// <summary>
    /// Destroys the object off the screen
    /// </summary>
    private void DestroyObjectOffScreen()
    {
        if (gameObject.transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
}