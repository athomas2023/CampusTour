using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInputs : MonoBehaviour
{
    public GameObject Controller;

    [SerializeField]
    private InputActionAsset leftClickAction;

    //[SerializeField]
    //private TagManagerData tagManagerData;

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
        if (leftClickAction != null && leftClickAction.FindAction("LeftClick").triggered)
        {
            // Place your teleportation or other logic here
        }
    }
}