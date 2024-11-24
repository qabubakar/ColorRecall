using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintableObject : MonoBehaviour
{
    private Renderer objectRenderer;
    private GameManager gameManager;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnMouseDown()
    {
        if (GameManager.selectedMaterial != null)
        {
            // Apply the selected material color to this object
            objectRenderer.material.color = GameManager.selectedMaterial.color;

            // Register the user's guess
            gameManager.SetUserGuess(gameObject, GameManager.selectedMaterial.color);
        }
    }
}



