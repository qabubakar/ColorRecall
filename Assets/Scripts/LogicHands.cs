using UnityEngine;

public class MaterialTouchDetector : MonoBehaviour
{
    // This method is triggered when the CapsuleHand enters a trigger collider
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter.");
        // Get the Renderer component of the touched object
        Renderer objectRenderer = other.GetComponent<Renderer>();

        if (objectRenderer != null)
        {
            // Get the material of the touched object
            Material objectMaterial = objectRenderer.material;

            // Display material information in the console
            Debug.Log("Touched object: " + other.gameObject.name);
            Debug.Log("Material: " + objectMaterial.name);
            Debug.Log("Material color: " + objectMaterial.color);
        }
        else
        {
            Debug.Log("The touched object has no Renderer component.");
        }
    }
}