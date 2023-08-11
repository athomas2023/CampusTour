using UnityEngine;
using UnityEngine.InputSystem;

public class StateChange : MonoBehaviour
{
    private bool isActive = false;
    private HoverDetector hoverDetector; // Declare hoverDetector at the class level

    [Header("Hover State")]
    [SerializeField] public GameObject state;

    private void OnEnable()
    {
        hoverDetector = new HoverDetector(); // Instantiate hoverDetector
    }

    private void Update()
    {
        // Use the new Input System to get pointer events
        Pointer currentPointer = Pointer.current;

        if (currentPointer != null)
        {
            Vector2 cursorPosition = currentPointer.position.ReadValue();

            // Call the hover detection method and handle hover state change
            hoverDetector.DetectHover(cursorPosition);
            HandleHoverStateChanged(hoverDetector.IsHovering);
        }
    }

    private void HandleHoverStateChanged(bool isHovering)
    {
        isActive = isHovering;
        state.SetActive(isActive);
    }
}