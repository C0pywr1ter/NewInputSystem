using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsHW1 : MonoBehaviour
{
    private InputsHW controls;
    Rigidbody rigidbody;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        controls = new InputsHW();
        controls.Sphere.Jump.performed += _ => Jump();


    }
    private void FixedUpdate()
    {
        var value = controls.Sphere.Movement.ReadValue<Vector2>();
        var movement = new Vector3(value.x, 0, value.y);
        rigidbody.AddForce(movement * 3, ForceMode.Force);
    }

    private void OnEnable()
    {
        controls.Sphere.Enable();
    }
    private void OnDisable()
    {
        controls.Sphere.Disable();
    }

    void OnJump(InputAction.CallbackContext call)
    {
        Jump();
    }
    void Jump()
    {
        Vector3 jumpVector = new Vector3(0, 5, 0);
        rigidbody.AddForce(jumpVector, ForceMode.Impulse);
    }
}
