using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Invoke touch class
/// </summary>
public class InvokeTouch : MonoBehaviour
{

    /// <summary>
    /// Time it takes for the touch to go back to start pos
    /// </summary>
    public float resetTouchTime;

    /// <summary>
    /// Input manager
    /// </summary>
    private InputManager inputManager;

    /// <summary>
    /// Main camera
    /// </summary>
    private Camera cameraMain;

    /// <summary>
    /// Total player lives
    /// </summary>
    public int playerLives = 3;

    /// <summary>
    /// Called when the script instance is loaded
    /// </summary>
    private void Awake()
    {
        inputManager = InputManager.Instance;

        // Finds the camera every time
        cameraMain = Camera.main;
    }

    /// <summary>
    /// Called when the behaviour is enabled
    /// </summary>
    private void OnEnable()
    {
        inputManager.OnStartTouch += Move;
    }

    /// <summary>
    /// Called when the behaviour is disabled
    /// </summary>
    private void OnDisable()
    {
        inputManager.OnEndTouch -= Move;
    }

    /// <summary>
    /// Move object to the touched position
    /// </summary>
    /// <param name="screenPosition"></param>
    /// <param name="time"></param>
    public void Move(Vector2 screenPosition, float time)
    {
        Vector3 screenCordinates = new Vector3(screenPosition.x, screenPosition.y, cameraMain.nearClipPlane);

        // Convert to world coordinates
        Vector3 worldCoordinates = cameraMain.ScreenToWorldPoint(screenCordinates);

        worldCoordinates.z = 0;

        // Move object to where it was clicked at
        transform.position = worldCoordinates;

        // Reset position after click
        StartCoroutine(ResetTouchPosition());

    }

    /// <summary>
    /// Resets touch position after a touch
    /// </summary>
    IEnumerator ResetTouchPosition()
    {
        yield return new WaitForSeconds(resetTouchTime);
        transform.position = new Vector3(0, -4, 0);
    }

    /// <summary>
    /// Triggers when object collides with another object that has a collider.
    ///  - Requires a Rigidbody2d to be attached to parent
    ///  - Requires a Collider2d to be attached to parent
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Asteroid"))
        {
            // Gets the number field from the collision object of type EnemyController
            int asteroidNumber = collision.gameObject.GetComponent<EnemyController>().number;

            Debug.Log($"Asteroid had the number: {asteroidNumber} attached to it.");
            Debug.Log($"The soloution number is: {SolutionNumberInstance.solutionNumber}");

            Destroy(collision.gameObject);

            CheckSolutionOnAsteroidDestroy(asteroidNumber);

        }
    }

    /// <summary>
    ///  Checks to see if the Asteroid clicked matches with the soloution
    /// </summary>
    /// <param name="asteroidNumber">Number assigned to destroyed asteroid</param>
    private void CheckSolutionOnAsteroidDestroy(int asteroidNumber)
    {
        // Displays and randomly assigns soloution number after destroying object
        int soloutionNumber = SolutionNumberInstance.solutionNumber;
        Debug.Log($"The soloution number is: {soloutionNumber}");

        if (soloutionNumber.Equals(asteroidNumber))
        {
            Debug.Log("MATCH WAS MADE!");
            SolutionNumberInstance.numberA = Random.Range(0, 20);
            SolutionNumberInstance.numberB = Random.Range(0, 20);

            int determineOperation = Random.Range(0, 3);
            SolutionNumberInstance.operation = determineOperation;

            switch (determineOperation)
            {
                case 0:
                    SolutionNumberInstance.solutionNumber = SolutionNumberInstance.numberA + SolutionNumberInstance.numberB;
                    break;

                case 1:
                    SolutionNumberInstance.solutionNumber = SolutionNumberInstance.numberA - SolutionNumberInstance.numberB;
                    break;

                case 2:
                    SolutionNumberInstance.solutionNumber = SolutionNumberInstance.numberA * SolutionNumberInstance.numberB;
                    break;

                case 3:
                    SolutionNumberInstance.solutionNumber = SolutionNumberInstance.numberA / SolutionNumberInstance.numberB;
                    break;
            }

            Debug.Log($"The NEW soloution number is: {soloutionNumber}");
        }
        else
        {
            // Manage player lives - destroy hearts if the player gets answers wrong
            if (playerLives.Equals(3))
            {
                Destroy(GameObject.Find("Heart_3"));
                playerLives--;
            }
            else if (playerLives.Equals(2))
            {
                Destroy(GameObject.Find("Heart_2"));
                playerLives--;
            }
            else if (playerLives.Equals(1))
            {
                Destroy(GameObject.Find("Heart_1"));
                playerLives--;
            }
            else
            {
                Debug.Log("Player is out of lives.");
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            }
        }
    }
}
