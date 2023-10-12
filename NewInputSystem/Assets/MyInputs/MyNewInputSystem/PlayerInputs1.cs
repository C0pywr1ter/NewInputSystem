using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs1 : MonoBehaviour
{
    private PlayerInputs controls;
    Rigidbody rigidbody;
    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        controls = new PlayerInputs();
        controls.Player.Jump.performed +=  DoJump;//_ => Jump(); //вторая форма записи
    }
    private void Update()
    {
       var value = controls.Player.Jump.ReadValue<float>();
       
      Debug.Log(value);
    }
    private void FixedUpdate()
    {
        var value = controls.Player.Move.ReadValue<Vector2>();
        Debug.Log(value); 
        var movement = new Vector3(value.x, 0, value.y);
        rigidbody.AddForce(movement * 3, ForceMode.Force);
    }
    void DoJump(InputAction.CallbackContext call)   
    {
        Jump();
    }

    private void OnEnable() //создание объекта на сцене
    {
        controls.Player.Enable();
    }
    private void OnDisable() //удаление объекта на сцене
    {
        controls.Player.Disable();
    }
    void Jump()
    {
        rigidbody.AddForce(new Vector3(0, 5, 0),ForceMode.Impulse);
    }
}
