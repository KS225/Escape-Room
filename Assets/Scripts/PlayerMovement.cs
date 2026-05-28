using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 100f;
    public float gravity = -9.81f;

    public Transform playerCamera;

    private CharacterController controller;

    private float verticalRotation = 0f;
    private float verticalVelocity = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Movement Input
        Vector2 moveInput = Vector2.zero;

        if (Keyboard.current != null)
        {
            moveInput.x =
                (Keyboard.current.dKey.isPressed ? 1 : 0) -
                (Keyboard.current.aKey.isPressed ? 1 : 0);

            moveInput.y =
                (Keyboard.current.wKey.isPressed ? 1 : 0) -
                (Keyboard.current.sKey.isPressed ? 1 : 0);

            // Arrow keys support
            moveInput.x +=
                (Keyboard.current.rightArrowKey.isPressed ? 1 : 0) -
                (Keyboard.current.leftArrowKey.isPressed ? 1 : 0);

            moveInput.y +=
                (Keyboard.current.upArrowKey.isPressed ? 1 : 0) -
                (Keyboard.current.downArrowKey.isPressed ? 1 : 0);
        }

        // Convert movement direction
        Vector3 move =
            transform.right * moveInput.x +
            transform.forward * moveInput.y;

        // Gravity
        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;

        move.y = verticalVelocity;

        // Move Player
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Mouse Look
        if (Mouse.current != null)
        {
            Vector2 mouseDelta =
                Mouse.current.delta.ReadValue() *
                mouseSensitivity *
                Time.deltaTime;

            // Horizontal rotation
            transform.Rotate(Vector3.up * mouseDelta.x);

            // Vertical rotation
            verticalRotation -= mouseDelta.y;
            verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);

            playerCamera.localRotation =
                Quaternion.Euler(verticalRotation, 0f, 0f);
        }
    }
}