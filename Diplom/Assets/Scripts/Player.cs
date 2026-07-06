using UnityEngine;
using UnityEngine.InputSystem; 

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float _moveSpeed = 5f;

    private Vector2 _moveInput;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(_moveInput.x, 0f, _moveInput.y).normalized;
        _rigidbody.MovePosition(_rigidbody.position + movement * _moveSpeed * Time.fixedDeltaTime);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnMachineGun(InputAction.CallbackContext context)
    {
        if (context.performed) FireMachineGun();
    }

    public void OnBeam(InputAction.CallbackContext context)
    {
        if (context.performed) FireBeam();
    }

    public void OnLaunchSphere(InputAction.CallbackContext context)
    {
        if (context.performed) LaunchSphere();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed) Dash();
    }

    public void OnShield(InputAction.CallbackContext context)
    {
        if (context.performed) ActivateShield();
    }

    // Заглушки для умений

    private void FireMachineGun()
    {
        Debug.Log("Пулемёт");
    }

    private void FireBeam()
    {
        Debug.Log("Луч");
    }

    private void LaunchSphere()
    {
        Debug.Log("Сфера");
    }

    private void Dash()
    {
        Debug.Log("Рывок");
    }

    private void ActivateShield()
    {
        Debug.Log("Щит");
    }
}