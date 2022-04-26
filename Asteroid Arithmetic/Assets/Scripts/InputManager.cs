using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Input manager class - runs first
/// </summary>
[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviourSingleton<InputManager>
{
    /// <summary>
    /// Start touch event delegate that allows other script to dictate functionality
    /// </summary>
    /// <param name="position">Position</param>
    /// <param name="time">Time</param>
    public delegate void StartTouchEvent(Vector2 position, float time);

    /// <summary>
    /// Whats called from the script
    /// </summary>
    public event StartTouchEvent OnStartTouch;

    /// <summary>
    /// End touch event delegate that allows other script to dictate functionality
    /// </summary>
    /// <param name="position">Position</param>
    /// <param name="time">Time</param>
    public delegate void EndTouchEvent(Vector2 position, float time);

    /// <summary>
    /// Whats called from the script
    /// </summary>
    public event EndTouchEvent OnEndTouch;

    /// <summary>
    /// Touch controls object
    /// </summary>
    private TouchControls touchControls;

    /// <summary>
    /// Called when the script instance is loaded
    /// </summary>
    private void Awake()
    {
        touchControls = new();
    }

    /// <summary>
    /// Called when the behaviour is enabled
    /// </summary>
    private void OnEnable()
    {
        touchControls.Enable();
    }

    /// <summary>
    /// Called when the behaviour is disabled
    /// </summary>
    private void OnDisable()
    {
        touchControls.Disable();
    }

    /// <summary>
    /// Called once before Update() is called for the first time
    /// </summary>
    private void Start()
    {
        // Subscribes to event when we press down on the screen
        touchControls.Touch.TouchPress.started += context => StartTouch(context);
        touchControls.Touch.TouchPress.canceled += context => EndTouch(context);

    }

    /// <summary>
    /// Start touching
    /// </summary>
    /// <param name="context">Context</param>
    private void StartTouch(InputAction.CallbackContext context)
    {
        // Get touch position in screen cords 
        Vector2 touchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();

        // Prints out where we touch in screen cordinates
        Debug.Log($"Touch started {touchPosition}");

        if (OnStartTouch is not null)
        {
            OnStartTouch(touchPosition, (float)context.startTime);
        }
    }

    /// <summary>
    /// End touching
    /// </summary>
    /// <param name="context">Context</param>
    private void EndTouch(InputAction.CallbackContext context)
    {
        // Get touch position in screen cords 
        Vector2 touchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();

        // Prints out where we touch in screen cordinates
        Debug.Log($"Touch ended {touchControls.Touch.TouchPosition.ReadValue<Vector2>()}");

        if (OnEndTouch is not null)
        {
            OnEndTouch(touchPosition, (float)context.time);
        }
    }
}
