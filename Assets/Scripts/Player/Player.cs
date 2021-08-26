using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variabl//
    [SerializeField] private float runSpeed = 12f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float groundDist = 0.4f;
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] float health = 100f;

    public Transform playerBody;
    public Transform groundCheck;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    //References//
    //[SerializeField] private Ui_Inventory ui_Inventory;
    public CharacterController characterController;
    //private Inventory inventory;

    private void Awake()
    {
        //inventory = new Inventory();
        //ui_Inventory.SetInventory(inventory);
    }

    void Update()
    {   
        RotateMove();
        Run();
    }


    private void RotateMove()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX);
    }
    private void Run()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(Vector3.ClampMagnitude(move, 1.0f) * runSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
    
}
