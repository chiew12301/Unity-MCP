using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public float jumpForce = 5.0f;
    public float gravity = -9.81f;

    [Header("Look Settings")]
    public float mouseSensitivity = 2.0f;
    public float lookXLimit = 90.0f;
    public Transform playerCamera;
    public bool lockCursor = true;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // Private variables
    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private bool isGrounded;
    private Vector3 velocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
        // Lock cursor if specified
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        // Create camera if not assigned
        if (playerCamera == null)
        {
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                playerCamera = mainCamera.transform;
            }
            else
            {
                Debug.LogError("Main camera not found and no camera assigned to FirstPersonController!");
            }
        }
    }

    void Update()
    {
        // Check if player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small value to ensure grounding
        }

        // Handle player movement
        HandleMovement();
        
        // Handle player looking
        HandleLook();
        
        // Apply gravity and jumping
        HandleGravityAndJump();
    }

    void HandleMovement()
    {
        // Get input axes
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Apply speed (run or walk)
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        
        // Move the controller
        characterController.Move(move * currentSpeed * Time.deltaTime);
    }

    void HandleLook()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Calculate camera rotation for looking up and down
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        // Apply rotations
        playerCamera.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.rotation *= Quaternion.Euler(0f, mouseX, 0f);
    }

    void HandleGravityAndJump()
    {
        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // Apply gravity-based movement
        characterController.Move(velocity * Time.deltaTime);
    }
}
