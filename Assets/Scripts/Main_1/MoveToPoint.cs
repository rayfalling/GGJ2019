﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    private GameObject Player;

    
    //public GameObject[] linkedpoints;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (!Player.GetComponent<PlayMove>().CanMoving && !Player.GetComponent<PlayMove>().isMapMoving)
        {
            //Player.transform.Translate(this.transform.position - Player.transform.position);
            GameManagerMain.gm.ChooseCar.SetActive(true);
            Vector3 cameraPos = Camera.main.WorldToScreenPoint(this.transform.position);
            GameManagerMain.gm.ChooseCar.transform.position = cameraPos;
            GameObject.Find("UIManager").GetComponent<UIManager>().SetTarget(this.gameObject);
            //Player.GetComponent<PlayMove>().PlayerMoveTo(this.gameObject);
        }

    }
    
    //public bool IsLinked(GameObject point)
    //{
    //    foreach(GameObject go in linkedpoints)
    //    {
    //        if (go.transform == point.transform)
    //            return true;
    //    }
    //    Debug.Log("未连接");
    //    return false;
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.GetComponent<PlayMove>().StopMoving();
        }
    }
}
