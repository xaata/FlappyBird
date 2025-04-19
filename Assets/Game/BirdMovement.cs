using UnityEngine;
using UnityEngine.InputSystem;

public class BirdMovement : MonoBehaviour
{
    [SerializeField]private float _jumpForce;
    private InputSystem_Actions _InputActions;
    private Rigidbody2D _rb;

    private void Awake()
    {        
        _InputActions = new InputSystem_Actions();
        _rb = GetComponent<Rigidbody2D>();
        _InputActions.Player.Jump.performed += ctx => Jump(ctx);  
    }
    private void Jump(InputAction.CallbackContext ctx)
    {
        //Debug.Log("jump");
        _rb.linearVelocityY = _jumpForce;
    }
    private void OnEnable() => _InputActions.Enable();
    private void OnDisable() => _InputActions.Disable();
}
