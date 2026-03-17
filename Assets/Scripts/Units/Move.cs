using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
    public Camera cam;

    public float speed = 10f;
    public float jumpForce = 5f;
    public float sensitivity = 0.5f;
    public float stopForce = 5f;

    private float xRotation = 0f;
    
    public bool IsMenuOpen = true;

    private void Start()
    {
        rb.linearDamping = stopForce;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame) {
            IsMenuOpen = !IsMenuOpen;
            CursorToggler(IsMenuOpen);
        }

        if (IsMenuOpen) return;
        CameraWork(); 
        Movement();
    }

    public void CursorToggler(bool val)
    {
        Cursor.lockState = val ? CursorLockMode.None : CursorLockMode.Locked;
    }

    private void CameraWork()
    {
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float msX = mouseDelta.x * sensitivity;
        float msY = mouseDelta.y * sensitivity;

        transform.Rotate(Vector3.up * msX);

        xRotation -= msY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private void Movement()
    {
        
        Vector3 inputDir = Vector3.zero;

        if (Keyboard.current.wKey.isPressed) inputDir += transform.forward;
        if (Keyboard.current.sKey.isPressed) inputDir -= transform.forward;
        if (Keyboard.current.aKey.isPressed) inputDir -= transform.right;
        if (Keyboard.current.dKey.isPressed) inputDir += transform.right;
        
        if (inputDir != Vector3.zero)
            rb.AddForce(inputDir.normalized * speed); 
        
    }
}