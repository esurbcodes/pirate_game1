using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelToggle : MonoBehaviour
{
    // Start is called before the first frame updat

    void Start()
    {
        Invoke("Fade", 1.5f);
    }

    void Fade()
    {
        this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
    }
    

  
}
