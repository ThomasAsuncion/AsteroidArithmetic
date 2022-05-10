using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolutionNumberInstance : MonoBehaviour
{
    /// <summary>
    /// Number to the solution
    /// </summary>
    public static int solutionNumber = 0;

    /// <summary>
    /// Reference to text on GUI
    /// </summary>
    public Text displayProblem;

    /// <summary>
    /// First number to the problem
    /// </summary>
    public static int numberA = 0;

    /// <summary>
    /// First number to the problem
    /// </summary>
    public static int numberB = 0;

    /// <summary>
    /// Number which determines operation that will be performed
    /// - 0: Addition
    /// - 1: Subtraction
    /// - 2: Multiplication
    /// - 3: Divison
    /// </summary>
    public static int operation;

    // Start is called before the first frame update
    void Start()
    {
        // Intialize text
        displayProblem = FindObjectOfType<Text>();

        displayProblem.text = numberA.ToString() + " + " + numberB.ToString() + " = ?";
    }

    // Update is called every frame
    void Update()
    {
        // Display addition
        if (operation.Equals(0))
        {
            displayProblem.text = numberA.ToString() + " + " + numberB.ToString() + " = ?";
        }

        // Display subtraction
        if (operation.Equals(1))
        {
            displayProblem.text = numberA.ToString() + " - " + numberB.ToString() + " = ?";
        }

        // Display multiplication
        if (operation.Equals(2))
        {
            displayProblem.text = numberA.ToString() + " * " + numberB.ToString() + " = ?";
        }

        // Display division
        if (operation.Equals(3))
        {
            displayProblem.text = numberA.ToString() + " / " + numberB.ToString() + " = ?";
        }
    }
}
