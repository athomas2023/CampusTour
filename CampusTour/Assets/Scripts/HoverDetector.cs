using UnityEngine;
using System;

public class HoverDetector
{
    private bool isHovering = false;

    public bool IsHovering
    {
        get { return isHovering; }
    }

    public event Action<bool> OnHoverStateChanged; // Event for hover state change

    public void DetectHover(Vector3 cursorPosition)
    {
        // Raycast from cursor position to detect hover
        Ray ray = Camera.main.ScreenPointToRay(cursorPosition);
        RaycastHit hit;

        // Perform the raycast
        bool wasHovering = isHovering;
        isHovering = Physics.Raycast(ray, out hit);

        if (isHovering != wasHovering && OnHoverStateChanged != null)
        {
            OnHoverStateChanged.Invoke(isHovering); // Invoke the event
        }

        if (isHovering)
        {
            Debug.Log("Hovering over an object with tag: " + hit.transform.tag);
        }
        else
        {
            Debug.Log("No object detected.");
        }
    }
}