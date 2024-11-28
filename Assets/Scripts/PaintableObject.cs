using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushPainter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the interacting object has the tag "paintable"
        
        if (other.CompareTag("brush"))
        {
            Debug.Log("Interaction with paintable object detected.");

            // Paint the object with the brush's material
            Renderer brushRenderer = other.GetComponent<Renderer>();
            Renderer paintableRenderer = GetComponent<Renderer>();
            

            if (paintableRenderer != null && brushRenderer != null)
            {
                paintableRenderer.material = brushRenderer.material;
                Debug.Log("Paintable object painted with brush material: " + brushRenderer.material.name);
            }
        }
        else
        {
            Debug.Log("Collision with non-paintable object.");
        }
    }
}