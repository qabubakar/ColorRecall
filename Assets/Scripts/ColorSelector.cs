using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelector : MonoBehaviour
{
    public Material colorMaterial; // Material for this color button

    void OnMouseDown()
    {
        // Select the color when clicked with the mouse
        SelectColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the interacting object has the tag "brush"
        if (other.CompareTag("brush"))
        {
            Debug.Log("Interaction with brush detected.");

            // Set the material of the "brush" object to match this object's material
            Renderer brushRenderer = other.GetComponent<Renderer>();
            if (brushRenderer != null && colorMaterial != null)
            {
                brushRenderer.material = colorMaterial;
                Debug.Log("Brush material changed to: " + colorMaterial.name);
            }

            // Update the global GameManager selected material (optional)
            SelectColor();
        }
    }

    private void SelectColor()
    {
        if (colorMaterial != null)
        {
            GameManager.selectedMaterial = colorMaterial;
            Debug.Log("Selected material: " + colorMaterial.name);
        }
    }
}