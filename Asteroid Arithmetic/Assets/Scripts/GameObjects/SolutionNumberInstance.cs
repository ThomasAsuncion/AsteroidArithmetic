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

    // Start is called before the first frame update
    void Start()
    {
        // Intialize text
        displayProblem = FindObjectOfType<Text>();

        displayProblem.text = numberA.ToString() + " + " + numberB.ToString() + " = ?";
    }

    void Update()
    {
        displayProblem.text = numberA.ToString() + " + " + numberB.ToString() + " = ?";
    }
}
