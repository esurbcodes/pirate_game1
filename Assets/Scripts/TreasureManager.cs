using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureManager : MonoBehaviour
{
    public int treasureCount;
    public Text treasureText;

    // Update is called once per frame
    void Update()
    {
        treasureText.text = ": " + treasureCount.ToString();
    }
}
