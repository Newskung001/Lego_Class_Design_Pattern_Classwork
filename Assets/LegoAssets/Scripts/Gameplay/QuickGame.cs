using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Quit game");
            Application.Quit();
        }
    }
}
