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
    private float change;
    //[Range(-1,1)]
    //public float test;
    // Start is called before the first frame update
    void Start()
    {
        //test = 0;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Input.gyro.enabled = true;
        change = change = Input.gyro.attitude.x;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Input.gyro.attitude.ToString();
        change = Input.gyro.attitude.x;

        //change = test;
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
