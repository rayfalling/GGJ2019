using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public Transform[] grounds;
    private float offset;
    private float speed;
    private float totime;
    private float stimer;
    public bool isstop;
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    // Start is called before the first frame update
    void Start()
    {
        offset = grounds[1].position.y - grounds[0].position.y;
        grounds[2].position = new Vector2(grounds[0].position.x, grounds[1].position.y + offset);
        speed = 5f;
        totime = 0f;
        stimer = 0f;
        isstop = false;
    }

    // Update is called once per frame
    void Update()
    {
        totime += Time.deltaTime;
        if (!isstop)
        {
            stimer += Time.deltaTime;
            stimer = totime;
            foreach (var ground in grounds)
                ground.transform.Translate(Vector2.up * -0.2f * speed * Time.deltaTime * totime);
        }
        else
        {
            if (stimer > 0)
                stimer -= Time.deltaTime * 20;
            if(stimer<=0)
                stimer = 0;
            foreach (var ground in grounds)
                ground.transform.Translate(Vector2.up * -0.2f * speed * Time.deltaTime * stimer);
            totime = 0;
        }
        for(int i=0;i<=2;i++)
        {
            if(grounds[i].position.y<=-10)
            {
                if (i == 0)
                    grounds[i].position = new Vector2(grounds[i].position.x, grounds[2].position.y + offset);
                else
                    grounds[i].position = new Vector2(grounds[i].position.x, grounds[i-1].position.y + offset);
            }
        }
    }
    public void stop()
    {
        if (isstop)
            isstop = false;
        else
            isstop = true;
    }
}
