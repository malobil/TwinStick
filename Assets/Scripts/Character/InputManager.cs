using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private StandardControls m_Inputs;
    private bool m_ControllerConnected = false ;

    public StandardControls Inputs { get => m_Inputs; set => m_Inputs = value; }
    public bool ControllerConnected { get => m_ControllerConnected; set => m_ControllerConnected = value; }

    private void Awake()
    {
        DetectControllers();
        InitializeInputs();
        EnableInput();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeInputs()
    {
        Inputs = new StandardControls();
        InputSystem.onDeviceChange += OnControllerChanged;
    }

    private void EnableInput()
    {
        Inputs.Enable();
    }

    private void DisableInput()
    {
        Inputs.Disable();
    }

    private void OnControllerChanged(InputDevice device, InputDeviceChange change)
    {
        DetectControllers();
    }

    private void DetectControllers()
    {
        if(Gamepad.all.Count > 0)
        {
            ControllerConnected = true;
        }
        else
        {
            ControllerConnected = false;
        }
    }

    private void OnDisable()
    {
        InputSystem.onDeviceChange -= OnControllerChanged;
    }
}
