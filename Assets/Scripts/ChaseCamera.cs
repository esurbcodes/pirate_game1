using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
  public GameObject target;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position, .1f);
        
        
    }
}
