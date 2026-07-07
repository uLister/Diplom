using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Ссылки (Перетащить в Инспекторе)")]
    [SerializeField] private Transform _target;          
    [SerializeField] private PlayerInput _playerInput; 

    [Header("Настройки камеры")]
    [SerializeField] private float _distance = 10f;      
    [SerializeField] private float _rotationSpeed = 0.2f;
    [SerializeField] private float _minPitch = -10f;     
    [SerializeField] private float _maxPitch = 80f;      

    private bool _isRotationEnabled;
    private Vector2 _lookInput;
    private float _yaw;   
    private float _pitch; 

    private Vector2 _savedMousePosition; 

    private void Start()
    {
        Vector3 angles = transform.eulerAngles;
        _yaw = angles.y;
        _pitch = angles.x;
    }

    private void OnEnable()
    {
        if (_playerInput != null) 
        {
            _playerInput.OnCameraRotateEnableInput += SetRotationEnable;
            _playerInput.OnCameraLookInput += UpdateLookInput;
        }
    }

    private void OnDisable()
    {
        if (_playerInput != null) 
        {
            _playerInput.OnCameraRotateEnableInput -= SetRotationEnable;
            _playerInput.OnCameraLookInput -= UpdateLookInput;
        }
    }

    private void SetRotationEnable(bool isEnabled)
    {
        _isRotationEnabled = isEnabled;

        if (isEnabled)
        {
            if (Mouse.current != null)
            {
                _savedMousePosition = Mouse.current.position.ReadValue();
            }

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (Mouse.current != null)
            {
                Mouse.current.WarpCursorPosition(_savedMousePosition);
            }
        }
    }

    private void UpdateLookInput(Vector2 delta)
    {
        _lookInput = delta;
    }

    private void LateUpdate()
    {
        if (_target == null) return;

        if (_isRotationEnabled)
        {
            _yaw += _lookInput.x * _rotationSpeed;
            _pitch -= _lookInput.y * _rotationSpeed; 
            
            _pitch = Mathf.Clamp(_pitch, _minPitch, _maxPitch); 
        }

        Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0);
        Vector3 position = _target.position - (rotation * Vector3.forward * _distance);

        transform.position = position;
        transform.rotation = rotation;
    }
}