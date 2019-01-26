using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBegin : MonoBehaviour
{
    public int TimeLeft;
    private float TimeCount;
    public Text TimeText;
    // Start is called before the first frame update
    void Start()
    {
        TimeText.text = TimeLeft.ToString();
        TimeCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (TimeLeft > 0)
        {
            TimeCount += Time.deltaTime;
            if(TimeCount >= 1)
            {
                TimeLeft -= 1;
                TimeCount = 0;
            }
            TimeText.text = TimeLeft.ToString();
        }
        else
        {
            TimeText.gameObject.SetActive(false);
            GameManager_GameBall.gm.GameBegin();
            this.enabled = false;
        }
    }
}
