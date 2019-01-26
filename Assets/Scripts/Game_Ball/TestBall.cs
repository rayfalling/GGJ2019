using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBall : MonoBehaviour
{
    public Text text;
    public Transform[] LeftGO;
    public Transform[] RightGO;
    public float speed;

    //private float dir;
    private float change;
    //[Range(-1,1)]
    //public float test;
    // Start is called before the first frame update

    void Start()
    {
        //test = 0;
        
        Input.gyro.enabled = true;
        change = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager_GameBall.gm.IsPlaying() == false)
            return;

        //if (Screen.orientation == ScreenOrientation.LandscapeLeft)
        //    dir = 1;
        //else if (Screen.orientation == ScreenOrientation.LandscapeRight)
        //    dir = -1;

        text.text = Input.gyro.attitude.ToString();
        change = Input.gyro.attitude.w-0.4f;
        
        Debug.Log(change);

        //change = test;
        speed = speed + Time.deltaTime * 0.05f;
        Vector3 cv = new Vector3(change, 0, 0) * speed;
        foreach (Transform posi in LeftGO)
        {
            posi.position += cv;
        }
        foreach (Transform posi in RightGO)
        {
            posi.position += cv;
        }
        //change = test;
        //change = Input.gyro.attitude.x
    }
}
