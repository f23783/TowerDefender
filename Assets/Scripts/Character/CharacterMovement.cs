using UnityEngine;

public class CharacterMovement : MonoBehaviour
{   
    [Header("Movement Settings")]
    [SerializeField]private float moveSpeed;
    [SerializeField]private float rotationSpeed;

    [Header("Jump Settings")]
    [SerializeField]private Transform groundCheck;
    [SerializeField]private float groundCheckDistance = 0.3f;
    [SerializeField]private LayerMask groundLayer;
    [SerializeField]private float jumpForce = 5f;


    [Header("References")]
    private Vector2 moveDirection;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    private void Update() {
        Jump();
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 moveValue = InputManager.instance.move.ReadValue<Vector2>();

        moveValue.y = 0f;
        
        return moveValue;
    }

    private void MovePlayer()
    {
        moveDirection = GetMovementVectorNormalized();

        rb.AddForce(moveDirection * moveSpeed, ForceMode2D.Force);

    }

    private bool isGrounded()
    {
        return Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
    }

        private void Jump()
    {
        if (InputManager.instance.jump.IsPressed() && isGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
       
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance);
    }
}
