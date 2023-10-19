using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandShoot : MonoBehaviour
{
    public GameObject cannonBall;

    void Update()
    {
        Instantiate(cannonBall, this.transform.position, Quaternion.identity);
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(3);

        StartCoroutine("Shoot");
    }
}
