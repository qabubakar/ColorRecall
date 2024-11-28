using UnityEngine;

public class ShapeCollisionHandler : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Detectar si el objeto colisionado tiene el componente ColorSelector
        var colorSelector = collision.gameObject.GetComponent<ColorSelector>();
        if (colorSelector != null)
        {
            // Obtener el color del objeto colisionado
            Color collidedColor = colorSelector.colorMaterial.color;

            // Cambiar el color del objeto actual
            GetComponent<Renderer>().material.color = collidedColor;

            // Notificar al GameManager sobre la selección
            gameManager.SetUserGuess(gameObject, collidedColor);
        }
    }
}