using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuitScript : MonoBehaviour
{
   public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }
}
