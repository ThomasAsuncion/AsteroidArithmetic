using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Invoke touch class
/// </summary>
public class InvokeTouch : MonoBehaviour
{
    /// <summary>
    /// Input manager
    /// </summary>
    private InputManager inputManager;
    
    /// <summary>
    /// Main camera
    /// </summary>
    private Camera cameraMain;

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
        transform.position = worldCoordinates;
    }
}
