using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public GameObject panel;
    public void start()
    {
        this.GetComponent <Animator> ().SetTrigger("end");
        panel.SetActive(true);
        Invoke("LoadGame", 1.5f);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("game");
    }
}
