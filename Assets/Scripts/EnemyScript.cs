using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //  *   *  Enemy AI  *    *
    public Transform player;
    public Transform target;
    
    public float moveSpeed = 5f;
    public float rotSpeed;
    public float rotationModifier;
    //  *     *     *    *    *

    //  *     Enemy Health    *
    public float health;
    //  *     *     *    *    *

    private Rigidbody2D rb;
    //  *    Enemy Movement   *
    private Vector2 movement;
    //  *     *     *    *    *


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //  *   *  Enemy AI  *    *
        Vector3 direction = player.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        //  *     *     *    *    *
    }

    //  *   *  Enemy AI  *    *
    private void FixedUpdate()
    {

        moveCharacter(movement);

        //Rotate
        Vector3 vectorToTarget = player.position - transform.position;

        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;

        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotSpeed);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    //  *     *     *    *    *
}