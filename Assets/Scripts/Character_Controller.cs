using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    CharacterController characterController;
    public float MovementSpeed = 1; // How fast the player moves
    public float Gravity = 9.8f; // Earth gravity
    private float velocity = 0;
    public Camera cam;
    private void Start()
    {
        characterController = GetComponent<CharacterController>(); // Gets the character controller component
    }
    void Update()
    {
        // player movement - forward, backward, left, right
        float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
        float vertical = Input.GetAxis("Vertical") * MovementSpeed;
        characterController.Move((cam.transform.right * horizontal + cam.transform.forward * vertical) * Time.deltaTime);

        //Gravity
        if (characterController.isGrounded)
        {
            velocity = 0; // Checks if the player has jumped
        }
        else
        {
            velocity -= Gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }
    }
}