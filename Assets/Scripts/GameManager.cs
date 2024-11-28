using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] shapes; // Array of shapes (Cube, Sphere, Cylinder)
    public GameObject[] colorButtons; // Array of color buttons
    private Dictionary<GameObject, Color> originalColors = new Dictionary<GameObject, Color>();
    private Dictionary<GameObject, Color> userGuesses = new Dictionary<GameObject, Color>();
    public float showTime = 5f; // Time to display colors
    public float guessTime = 15f; // Time to guess
    public Material whiteMaterial; // Material to reset shapes to white

    private int score = 0; // Player's score
    private int level = 1; // Current game level


    //public Text scoreText; // UI Text to display the score
    //public Text levelText; // UI Text to display the level
    //public Text messageText; // UI Text to display messages like "Correct!" or "Try Again"
    //public GameObject buttonsPanel; // Panel to hold "Next Level" and "Try Again" buttons
    //public Button nextLevelButton; // Button to proceed to the next level
    //public Button tryAgainButton; // Button to retry the current level



    public static Material selectedMaterial; // Currently selected material

    void Start()
    {
        StartCoroutine(GameFlow());
    }

    IEnumerator GameFlow()
    {
        while (true)
        {
            Debug.Log("Level " + level);

            AssignRandomColors();
            ShowColors();

            yield return new WaitForSeconds(showTime);

            ResetColorsToWhite();

            yield return StartCoroutine(WaitForGuesses());

            if (CheckGuesses())
            {
                Debug.Log("Correct! Moving to the next level.");
                level++;
            }
            else
            {
                Debug.Log("Incorrect! Try again.");
            }

            yield return new WaitForSeconds(2); // Short delay before the next round
        }
    }

    void AssignRandomColors()
    {
        originalColors.Clear();

        foreach (var shape in shapes)
        {
            // Assign a random color from the color buttons
            var randomColorButton = colorButtons[Random.Range(0, colorButtons.Length)];
            var randomColor = randomColorButton.GetComponent<ColorSelector>().colorMaterial.color;

            originalColors[shape] = randomColor;

            // Set the shape's material to the random color
            shape.GetComponent<Renderer>().material.color = randomColor;
        }
    }

    void ShowColors()
    {
        foreach (var shape in shapes)
        {
            shape.GetComponent<Renderer>().material.color = originalColors[shape];
        }
    }

    void ResetColorsToWhite()
    {
        foreach (var shape in shapes)
        {
            shape.GetComponent<Renderer>().material.color = whiteMaterial.color;
        }

        userGuesses.Clear();
    }

    IEnumerator WaitForGuesses()
    {
        float timer = guessTime;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
    }

    bool CheckGuesses()
    {
        foreach (var shape in shapes)
        {
            if (!userGuesses.ContainsKey(shape) || userGuesses[shape] != originalColors[shape])
            {
                return false;
            }
        }

        score += 1;
        Debug.Log("Score: " + score);
        return true;
    }

    public void SetUserGuess(GameObject shape, Color color)
    {
        userGuesses[shape] = color;
    }
}