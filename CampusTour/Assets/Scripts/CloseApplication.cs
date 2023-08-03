using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Import the Input System namespace

public class CloseApplication : MonoBehaviour
{
    // Reference to the Input Action asset. This will be set in the Unity Inspector.
    [SerializeField]
    private InputActionAsset escInputAction;

    private void OnEnable()
    {
        // Enable the "Closeapp" action when this script is enabled
        escInputAction.Enable();
    }

    private void OnDisable()
    {
        // Disable the "Closeapp" action when this script is disabled
        escInputAction.Disable();
    }

    private void Update()
    {
        // Check if the "Esc" key is pressed
        if (escInputAction != null && escInputAction.FindAction("Closeapp").triggered)
        {
            CloseApplicationMethod();
        }
    }

    private void CloseApplicationMethod()
    {
        // Check if the game is running in the Unity editor or a standalone build
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Exit Play mode in the editor
        #else
            Application.Quit(); // Quit the application in a standalone build
        #endif
    }
}