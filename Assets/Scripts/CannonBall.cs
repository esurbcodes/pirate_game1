using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{

    //set speed of cannonball shot
    public float ShootSpeed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D r2d = this.GetComponent<Rigidbody2D>();
        r2d.velocity =transform.right*ShootSpeed;

        Destroy(this.gameObject ,3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
