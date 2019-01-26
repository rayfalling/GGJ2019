using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human : MonoBehaviour
{
    private float movespeed;
    private GameObject car;
    private bool isright;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("playercar");
        movespeed = 0.5f;
        isright = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.y - car.transform.position.y) <= 5)
        {
            if (transform.position.x <= 0)
                transform.Translate(Vector2.left * movespeed * Time.deltaTime);
            else
                transform.Translate(Vector2.right * movespeed * Time.deltaTime);
        }
        else
           move();
    
    }
    private void move()
    {
        if (isright)
            transform.Translate(Vector2.right * movespeed * Time.deltaTime);
        else
            transform.Translate(Vector2.left * movespeed * Time.deltaTime);
        if (transform.position.x >= 2.04)
            isright = false;
        if (transform.position.x <= -2.14)
            isright = true;
    }
}
