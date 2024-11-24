using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorSelector : MonoBehaviour
{
    public Material colorMaterial; // Material for this color button

    void OnMouseDown()
    {
        if (colorMaterial != null)
        {
            GameManager.selectedMaterial = colorMaterial;
        }
    }
}
