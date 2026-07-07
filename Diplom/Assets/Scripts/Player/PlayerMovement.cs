using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;
    private Vector2 _currentMoveDirection;
    
    private Transform _cameraTransform; 

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        _cameraTransform = Camera.main.transform; 
    }

    private void OnEnable() => _playerInput.OnMoveInput += UpdateMoveDirection;
    private void OnDisable() => _playerInput.OnMoveInput -= UpdateMoveDirection;

    private void UpdateMoveDirection(Vector2 direction) => _currentMoveDirection = direction;

    private void FixedUpdate()
    {
        if (_cameraTransform == null) return; 

        Vector3 cameraForward = _cameraTransform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize(); 

        Vector3 cameraRight = _cameraTransform.right;
        cameraRight.y = 0f;
        cameraRight.Normalize();

        Vector3 movement = (cameraForward * _currentMoveDirection.y + cameraRight * _currentMoveDirection.x).normalized;

        _rigidbody.MovePosition(_rigidbody.position + movement * _moveSpeed * Time.fixedDeltaTime);
    }
}