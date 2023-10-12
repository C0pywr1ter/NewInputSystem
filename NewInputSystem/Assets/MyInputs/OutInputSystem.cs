using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutInputSystem : MonoBehaviour
{
  



    float moveSpeed = 5f;
    float jumpForce = 5f;

    Rigidbody rb;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");
        float verticalDirection = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horizontalDirection, verticalDirection);

        Move(direction);

        if (Input.GetMouseButtonDown(0))
            Shoot();
        if (Input.GetButtonDown("Jump"))
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void Move(Vector2 direction)
    {
        float scaledMoveSpeed = moveSpeed * Time.deltaTime;

        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        transform.position += moveDirection * scaledMoveSpeed;
    }

    private void Shoot()
    {
        Debug.Log("Shooting");
    }
}
    
