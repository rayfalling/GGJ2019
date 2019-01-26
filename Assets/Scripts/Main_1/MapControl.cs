using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    private float DoubleTouchCurrDis;
    private float DoubleTouchLastDis;

    private float DoubleTouchCurrPosX;
    private float DoubleTouchCurrPosY;
    private float DoubleTouchLastPosX;
    private float DoubleTouchLastPosY;

    private Transform Map;
    private bool isScale;
    private bool isScaling;
    private bool isMove;
    // Start is called before the first frame update
    void Start()
    {
        isScale = false;
        isScaling = false;
        isMove = false;
        Map = GameObject.Find("MainMap").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayMove>().CanMoving)
            return;
        if ((Input.touchCount == 2) && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved))
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            //Scale
            DoubleTouchCurrDis = Vector2.Distance(touch1.position, touch2.position);
            if(!isScale)
            {
                DoubleTouchLastDis = DoubleTouchCurrDis;
                isScale = true;
                GameObject.Find("Player").GetComponent<PlayMove>().isMapMoving = true;
            }
            float distance = DoubleTouchCurrDis - DoubleTouchLastDis;
            Debug.Log(distance);
            distance = (distance > 0 ? 0.01f : -0.01f);
            Map.localScale = Map.localScale * (1 + distance);
            isScaling = true;
            DoubleTouchLastDis = DoubleTouchCurrDis;

            
        }
        else
        {
            isScaling = false;
        }
        if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            //Move
            Touch touch0 = Input.GetTouch(0);
            DoubleTouchCurrPosX = touch0.position.x;
            DoubleTouchCurrPosY = touch0.position.y;
            if (!isMove)
            {
                DoubleTouchLastPosX = DoubleTouchCurrPosX;
                DoubleTouchLastPosY = DoubleTouchCurrPosY;
                isMove = true;
                GameObject.Find("Player").GetComponent<PlayMove>().isMapMoving = true;
            }
            float MovedisX = DoubleTouchCurrPosX - DoubleTouchLastPosX;
            float MovedisY = DoubleTouchCurrPosY - DoubleTouchLastPosY;
            //Debug.Log("X =" + MovedisX);
            //Debug.Log("Y =" + MovedisY);
            MovedisX *= 0.005f;
            MovedisY *= 0.005f;

            Map.position = new Vector3(Map.position.x + MovedisX, Map.position.y + MovedisY, Map.position.z);
            DoubleTouchLastPosX = DoubleTouchCurrPosX;
            DoubleTouchLastPosY = DoubleTouchCurrPosY;
        }
        else
        {
            isMove = false;
        }
        if(!isMove && !isScaling)
            GameObject.Find("Player").GetComponent<PlayMove>().isMapMoving = false;
    }
}
