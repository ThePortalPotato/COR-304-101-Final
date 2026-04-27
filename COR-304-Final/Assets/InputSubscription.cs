using UnityEngine;
using UnityEngine.InputSystem;

public class InputSubscription : MonoBehaviour
{
    public static InputSubscription Instance;
    public Vector2 LookInput { get; private set; } = Vector2.zero;
    public Vector2 MoveInput { get; private set; } = Vector2.zero;

    PlayerControls _Input = null;

    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        _Input = new PlayerControls();
        _Input.Player.Enable();
        _Input.Player.Look.performed += SetLook;
        _Input.Player.Look.canceled += SetLook;

        _Input.Player.Move.performed += SetMovement;
        _Input.Player.Move.canceled += SetMovement;
    }

    private void OnDisable()
    {
        _Input.Player.Look.performed -= SetLook;
        _Input.Player.Look.canceled -= SetLook;

        _Input.Player.Move.performed -= SetMovement;
        _Input.Player.Move.canceled -= SetMovement;

        _Input.Player.Disable();
    }

    void SetMovement(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    void SetLook(InputAction.CallbackContext context)
    {
        LookInput = context.ReadValue<Vector2>();
    }



}
