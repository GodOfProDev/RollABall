using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameInput _gameInput;
    [SerializeField] private float _moveSpeed = 7;
    [SerializeField] private float _jumpForce = 100;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _gameInput.OnJump += (sender, args) => HandleJump();
        _gameInput.OnDash += (sender, args) => HandleDash();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 inputVector = _gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        
        _rigidbody.AddForce(moveDir * _moveSpeed, ForceMode.Impulse);
    }

    private void HandleJump()
    {
        _rigidbody.AddForce(new Vector3(0, _jumpForce, 0), ForceMode.Impulse);
    }

    private void HandleDash()
    {
        // Nothing for now until we got proper camera system
        print("Dash");
    }
}
