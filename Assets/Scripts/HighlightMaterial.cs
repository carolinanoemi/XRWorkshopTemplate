using UnityEngine;


// This script highlights an object by changing its material when the mouse hovers over it

public class HighlightMaterial : MonoBehaviour
{
    [Header ("Objects to highlight")]
    [Tooltip("Drag the object you want to highlight here. Make sure it has a Collider Component")]
    public Renderer objectRenderer;

    [Header("Highlight Material")]
    [Tooltip("Drag the highlight Material you want to use")]
    public Material highlightMaterial;

    // private variables to store original material
    private Material originalMaterial;
    private bool isHighlighted = false;

    void Awake()
    {
        // Save the original material of the object
        if (objectRenderer != null)
        {
            originalMaterial = objectRenderer.material;
        }
        else
        {
            Debug.LogWarning("Target Renderer is not assigned.");
        }
    }

    // Method to highlight the object when mouse over 
    // Build -in Unity method
    // Unity listens for this method automatically calls when the mouse first moves over this object's collider
    // Only works if the object has a collider component
    void OnMouseEnter()
    {
        if (objectRenderer != null && highlightMaterial != null)
        {
            objectRenderer.material = highlightMaterial;
            isHighlighted = true;
        }

    }

    // Method to remove highlight when mouse exits
    // Build -in Unity method
    // Unity listens for this method automatically calls when the mouse first moves off this object's collider
    void OnMouseExit()
    {
        if (objectRenderer != null && isHighlighted)
        {
            objectRenderer.material = originalMaterial;
            isHighlighted = false;
        }

    }
}
