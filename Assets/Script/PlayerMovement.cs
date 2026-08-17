using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
   public float moveSpeed = 5f;
   public float jumpForce = 6f;
   public Transform groundCheck;
   public float groundCheckRadius = 0.2f;
   public LayerMask groundLayer;

    private Rigidbody rb;
    private Vector3 inputDirection;
    private bool isGrounded;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }


    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        inputDirection = new Vector3(h, 0f, v).normalized;
        isGrounded = Physics.CheckSphere(
            groundCheck.position, groundCheckRadius, groundLayer);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = inputDirection * moveSpeed;
        rb.linearVelocity = new Vector3(
            targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);
    }
}
