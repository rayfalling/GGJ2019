using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private GameObject panel;
    private bool hide;
    private void Start()
    {
        panel = transform.GetChild(0).gameObject;
        hide = true;
    }
    private void Update()
    {
        if(hide==false&&Input.GetMouseButtonDown(0))
        {
            panel.SetActive(false);
            hide = true;
        }
    }
    public void click()
    {
        panel.SetActive(true);
        hide = false;
    }
}
