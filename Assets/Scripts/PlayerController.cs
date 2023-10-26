using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // **Player Health **
    public float health;
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

    // **Treasure**
    public TreasureManager tm; //call treasuremanager script
    private System.Random rand = new System.Random(); //random variable for treasure respawn
    //  *     *     *    *


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 8;
        Debug.Log(health);
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
            var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            

            Instantiate(cannonBall,this.transform.position, Quaternion.AngleAxis(angle, Vector3.forward));

        }
        //  *     *     *    *
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

    private IEnumerator Respawn(Collider2D other, int time)
    {
        yield return new WaitForSeconds(time);
        //do da things
        other.gameObject.SetActive(true);
    }


    //   *  *  * Trigger Checks  *  *  *
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("treasure"))
        {
            other.gameObject.SetActive(false);
            tm.treasureCount++;
            StartCoroutine(Respawn(other, 5)); //set timer for 5 seconds 
        }
        other.gameObject.SetActive(false);
        //code for random respawn
        StartCoroutine(Respawn(other, rand.Next(5, 10)));

        // ** cannon ball checking for the ontrigger**
        if (other.gameObject.CompareTag("CannonBall"))
        {
            Destroy(other.gameObject);
            //reduce health after hit
            health = health - 1;

            //Game over after health gone
            if (health < 0)
            {
                GameObject gameUI = GameObject.Find("GameUI");
                gameUI.SendMessage("GameOver", SendMessageOptions.DontRequireReceiver);
                Destroy(this.gameObject);
            }
        }

        // ** sprite checking for the ontrigger**
        if (other.gameObject.CompareTag("Sprites"))
        {
                
            //reduce health after hit
            health = health - 1;

            //Game over after health gone
            if (health < 0)
            {
                GameObject gameUI = GameObject.Find("GameUI");
                gameUI.SendMessage("GameOver", SendMessageOptions.DontRequireReceiver);
                Destroy(this.gameObject);
            }
        }

        Debug.Log(health);

    }
    //  *     *     *    *     *      *

}
