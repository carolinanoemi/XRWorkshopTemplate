using UnityEngine;

// this script changes the material of a specified object when the ChangeMaterial function is called

public class ChangeObjectMaterial : MonoBehaviour
{
    [Header("Objects to change material on")]
    [Tooltip("Drag the object you want to change material on here")]
    public Renderer objectRenderer;

    [Header("New Material")]
    [Tooltip("Drag the new Material you want to change to")]
    public Material newMaterial;


    // private variables to store original materials
    private Material originalMaterial;
    private bool isOriginalMaterial = true;

    
    void Awake()
    {
        // Save the original materials of the object
        originalMaterial = objectRenderer.material;

        if (objectRenderer != null)
            {
                originalMaterial = objectRenderer.material;
              
            }
            else
            {
                Debug.LogWarning("Target Renderer is not assigned.");
            }

        
    }

    // This function can be called to change the material
    public void ChangeMaterial()
    {
       
       
        
            if (objectRenderer != null)
            {
                if (isOriginalMaterial)
                {
                    objectRenderer.material = newMaterial;
                }
                else
                {
                    objectRenderer.material = originalMaterial;
                }
            }
        
        isOriginalMaterial = !isOriginalMaterial;
    }


}
