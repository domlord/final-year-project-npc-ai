using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public static PlayerInput PlayerInput;
    
    
    
    public Vector2 MoveInput { get; private set; }
    public bool MoveIsPressed { get; private set; }

    
    
    
    private InputAction _moveInputAction;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        PlayerInput = GetComponent<PlayerInput>();

        _moveInputAction = PlayerInput.actions["Move"];

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        MoveInput = _moveInputAction.ReadValue<Vector2>();
        MoveIsPressed = _moveInputAction.IsPressed();
    }
}
