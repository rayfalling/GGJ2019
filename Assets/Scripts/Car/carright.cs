using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class carright : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    private GameObject player;
    private float movespeed;
    private bool canstop;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("playercar");
        movespeed = 7f;
        canstop = true;
    }
    void Update()
    {
        if (player.transform.position.x >= 1.94 && canstop)
        {
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            canstop = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (player.transform.position.x <= 1.94 && GameObject.Find("grounds").GetComponent<background>().isstop == false)
        {
            player.GetComponent<Rigidbody2D>().velocity = Vector2.right * movespeed;
            canstop = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
