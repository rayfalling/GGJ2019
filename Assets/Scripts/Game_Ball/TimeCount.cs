using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    public float TimeLimit;
    private float TimeUse;

    public Text TimeText;

    private bool Playing;
    public static TimeCount timecount;
    // Start is called before the first frame update
    void Start()
    {
        TimeUse = 0;
        TimeText.text = "剩余时间：" + TimeLimit.ToString();
        Playing = false;
        if(timecount == null)
        {
            timecount = this;
        }
    }
    public void GameFailed()
    {
        Playing = false;
        TimeText.text = "Failed!";
        GameManager_GameBall.gm.GameFailed(TimeUse);
       
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager_GameBall.gm.IsPlaying())
            Playing = true;
        if (Playing)
        {
            TimeUse += Time.deltaTime;
            float TimeLeft = TimeLimit - TimeUse;
            TimeText.text = "剩余时间：" + TimeLeft.ToString();
        }
        if(TimeUse > TimeLimit)
        {
            Playing = false;
            TimeText.text = "Win!";
            GameManager_GameBall.gm.GameWin();
        }

    }
}
