using UnityEngine;

// This script allows the user to click and drag to rotate the object in 3D space.

public class RotateObject : MonoBehaviour
{
    [Header("Drag Rotate Settings")]
    [Tooltip("How fast the object rotates when you drag the mouse")]
    public float rotationSpeed = 0.2f;

    // Is the mouse currently dragging this object?
    private bool isDragging = false;

    // Last mouse position (used to calculate movement delta)
    private Vector3 lastMousePosition;

    // Cached reference to the main camera (needed for raycasting)
    private Camera mainCamera;

    void Awake()
    {
        // Unity will find the camera tagged as MainCamera in the scene
        mainCamera = Camera.main;
    }

    void Update()
    {
        HandleMouseInput();
    }

    
    // Handles mouse down, drag, and mouse up input.
    void HandleMouseInput()
    {
        // If mouse button just pressed down
        if (Input.GetMouseButtonDown(0))
        {
            TryStartDragging();
        }

        // If mouse is held down and we are dragging this object
        if (Input.GetMouseButton(0) && isDragging)
        {
            DragRotate();
        }

        // if Mouse button released we stop dragging
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

   
    /// Check if we clicked on THIS object using a raycast.
   
    void TryStartDragging()
    {
        if (mainCamera == null) return;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Raycast into the scene from the mouse position
        if (Physics.Raycast(ray, out hit))
        {
            // Only start dragging if we hit THIS object
            if (hit.transform == transform)
            {
                isDragging = true;
                lastMousePosition = Input.mousePosition;
            }
        }
    }

    
    /// Rotate the object based on how much the mouse moved.
  
    void DragRotate()
    {
        Vector3 mouseDelta = Input.mousePosition - lastMousePosition;

        // Horizontal mouse movement = rotate around Y
        // Vertical mouse movement = rotate around X
        float rotationX = -mouseDelta.y * rotationSpeed;
        float rotationY = mouseDelta.x * rotationSpeed;

        // Rotate in place (local space)
        transform.Rotate(rotationX, rotationY, 0f, Space.Self);

        // Update last position so the delta stays small and smooth
        lastMousePosition = Input.mousePosition;
    }
}
