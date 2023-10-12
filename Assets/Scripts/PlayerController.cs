using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // **Player Health **
    public float Health;
    //  *     *     *    *

    // **Player Firing**
    public GameObject cannonBall;
    //  *     *     *    *

    // **Player Movement**
    public float moveSpeed;
    public Rigidbody2D rb;
    public float rotationSpeed;
    private Vector2 movement;
    //  *     *     *    *

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // **Player Movement**
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(movementX, movementY);
        //  *     *     *    *

        // **When fire button is pressed 
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(cannonBall);
        }
    }

    void FixedUpdate()
    {
        // **Player Movement**
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        RotateDirection();
        //  *     *     *    *
    }

    private void RotateDirection()
    {
        // **Player Movement**
        if (movement != Vector2.zero)
        {
            Quaternion playerRotation = Quaternion.LookRotation(transform.forward, movement);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, playerRotation, rotationSpeed * Time.deltaTime);
            rb.MoveRotation(rotation);
        }
        //  *     *     *    *
    }


}
