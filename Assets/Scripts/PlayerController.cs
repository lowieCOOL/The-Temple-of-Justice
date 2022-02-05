using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float xRotation;
    
    [Header("Looking")]

    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] float xRotationClamp = 70f;
    [SerializeField] Transform cameraTransform;

    [Header("Moving")]

    [SerializeField] float movementSpeed = 12f  ;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        PlayerRotation();
        PlayerMovement();
    }

    void PlayerRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float adjustedMouseX = mouseX * mouseSensitivity * Time.deltaTime;
        float adjustedMouseY = mouseY * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xRotationClamp, xRotationClamp);

        this.transform.Rotate(Vector3.up * adjustedMouseX);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void PlayerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;

        GetComponent<CharacterController>().Move(movement * movementSpeed * Time.deltaTime); ;
    }
}
