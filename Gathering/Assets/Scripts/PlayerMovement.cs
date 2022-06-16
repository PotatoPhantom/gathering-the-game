using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{

    [SerializeField] private Camera playerCamera;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float mouseSensitivity = 5f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float gravity = -9.81f;

    private Vector3 velocity;
    private Vector3 keyInput;
    private Vector2 mouseInput;
    private float xRotation;

    private void Start()
    {
        if (!IsClient)
        {
            playerCamera.enabled = false;
        } else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update()
    {
        if (IsClient)
        {
            keyInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            Move();
            Look();
        }
    }

    void Move()
    {
        Vector3 movementVector = transform.forward * keyInput.z + transform.right * keyInput.x;
        controller.Move(movementVector * moveSpeed * Time.deltaTime);

        if (controller.isGrounded)
        {
            velocity.y = -3f;
        } else
        {
            velocity.y -= gravity * -2f * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);
    }

    void Look()
    {
        xRotation -= mouseInput.y * mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(0f, mouseInput.x, 0f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
