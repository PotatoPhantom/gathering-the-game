using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{

    [SerializeField] private Camera playerCamera;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float mouseSensitivity = 3f;
    [SerializeField] private float moveSpeed = 2f;
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
            
        }
    }

    void Update()
    {
        if (IsClient)
        {
            keyInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            Move();
        }
    }

    void Move()
    {
        Vector3 movementVector = transform.forward * keyInput.z + transform.right * keyInput.x;

        transform.position += movementVector;
    }
}
