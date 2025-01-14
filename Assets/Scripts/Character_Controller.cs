using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        PlayerMovement();
        GravityControls();
        QuitLevel();
    }

    void PlayerMovement()
    {
        // player movement - forward, backward, left, right
        float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
        float vertical = Input.GetAxis("Vertical") * MovementSpeed;
        characterController.Move((cam.transform.right * horizontal + cam.transform.forward * vertical) * Time.deltaTime);
    }

    void GravityControls()
    {
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

    void QuitLevel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(0);
        }
    }
}