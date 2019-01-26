using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject human;
    public GameObject stop;
    private void Update()
    {
        if ((human.transform.position.y - transform.position.y) <= 10 && (human.transform.position.y - transform.position.y) >= -3)
            stop.SetActive(true);
        else
            stop.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag=="enermy")       //失败条件
        {
            Debug.Log("false");
            Time.timeScale = 0;
        }
    }
}
