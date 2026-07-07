using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public event Action<Vector2> OnMoveInput;
    public event Action OnMachineGunInput;

    public event Action<float> OnCameraZoomInput;
    public event Action<Vector2> OnCameraLookInput;
    public event Action<bool> OnCameraRotateEnableInput;

    private InputSystem_Actions _input;

    private void Awake()
    {
        _input = new InputSystem_Actions();

        _input.Player.Move.performed += ctx => OnMoveInput?.Invoke(ctx.ReadValue<Vector2>());
        _input.Player.Move.canceled += ctx => OnMoveInput?.Invoke(Vector2.zero);
        
        _input.Player.CameraZoom.performed += ctx => OnCameraZoomInput?.Invoke(ctx.ReadValue<Vector2>().y);
        
        
        _input.Player.CameraLook.performed += ctx => OnCameraLookInput?.Invoke(ctx.ReadValue<Vector2>());
        _input.Player.CameraLook.canceled += ctx => OnCameraLookInput?.Invoke(Vector2.zero); 
        
        
        _input.Player.CameraRotateEnable.started += ctx => OnCameraRotateEnableInput?.Invoke(true);
        _input.Player.CameraRotateEnable.canceled += ctx => OnCameraRotateEnableInput?.Invoke(false);
    }

    private void OnEnable() { _input.Enable(); }
    private void OnDisable() { _input.Disable(); }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
    
        Debug.Log($"[INPUT] Клавиатура работает! Нажат вектор: {value}");

        OnMoveInput?.Invoke(value);
    }
    private void OnMoveCanceled(InputAction.CallbackContext context) => OnMoveInput?.Invoke(Vector2.zero);
    private void OnAttackPerformed(InputAction.CallbackContext context) => OnMachineGunInput?.Invoke();
}