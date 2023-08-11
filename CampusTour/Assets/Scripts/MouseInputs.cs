using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInputs : MonoBehaviour
{
    public GameObject Controller;

    [SerializeField]
    private InputActionAsset leftClickAction;

    [SerializeField]
    private TagManagerData tagManagerData;

    private void OnEnable()
    {
        // Enable the input action when the script is enabled
        leftClickAction.Enable();

        // Show the cursor in both Editor and gameplay
        Cursor.visible = true;
    }

    private void OnDisable()
    {
        // Disable the input action when the script is disabled
        leftClickAction.Disable();
    }

    void Update()
    {
        if (leftClickAction !=null && leftClickAction.FindAction("LeftClick").triggered)
        {
            // Cast a ray from the camera's position in the direction of the mouse pointer
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object has one of the specified tags
                if (ArrayContainsTag(tagManagerData.tags, hit.transform.tag))
                {
                    // Teleport the Controller GameObject to the hit point
                    Controller.transform.position = hit.point;
                }
                else
                {
                    Debug.Log("Object hit but doesn't have the expected tag.");
                }
            }
            else
            {
                Debug.Log("No object detected.");
            }
        }
    }

    bool ArrayContainsTag(string[] tagArray, string tagToCheck)
    {
        foreach (string tag in tagArray)
        {
            if (tag == tagToCheck)
            {
                return true;
            }
        }
        return false;
    }
}