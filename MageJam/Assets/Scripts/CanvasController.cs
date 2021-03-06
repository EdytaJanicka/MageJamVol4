using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject Menu;


    void Start()
    {
        Time.timeScale = 0.000001f;
        Menu.SetActive(true);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(true);
            Time.timeScale = 0.000001f;
        }
    }

    public void Back()
    {
        Time.timeScale = 1f;
        Menu.SetActive(false);
    }
}
