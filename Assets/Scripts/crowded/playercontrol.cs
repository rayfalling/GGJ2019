using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    private GameObject player;
    private float force;
    private float lasttime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        force =0.003f;
        lasttime = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetTouch())
        // player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force,ForceMode2D.Impulse);
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //获取滑动的距离  Input.GetTouch(0).deltaPosition
            Vector2 touchDelPos = Input.GetTouch(0).deltaPosition;
            
                //滑动距离，，这个值很灵敏，注意不要设置的太小
            if (touchDelPos.x > 10)
            {
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force*Mathf.Abs(touchDelPos.x), ForceMode2D.Impulse);
               // player.transform.Translate(Vector2.right * 3*Time.deltaTime);
            }//X方向的作用滑动
            else if (touchDelPos.x < -10)
            {
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force* Mathf.Abs(touchDelPos.x), ForceMode2D.Impulse);
                //player.transform.Translate(Vector2.left * 3*Time.deltaTime);
            }
        }
        lasttime -= Time.deltaTime;
        if(lasttime<=0)                            //失败条件
        {
            Debug.Log("false");
            Time.timeScale = 0;
            lasttime = 10;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="Finish")          //成功条件
        {
            Debug.Log("true");
            Time.timeScale = 0;
        }
    }
}
