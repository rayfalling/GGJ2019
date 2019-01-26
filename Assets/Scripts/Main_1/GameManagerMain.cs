using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerMain : MonoBehaviour
{
    enum GameState { Begin, Playing, Win, Failed};
    private int[] temp = new int[5];

    private float Money;
    private float LeftTime;

    private GameState state;

    public static GameManagerMain gm;

    public Text timeText;
    public Text moneyText;
    public GameObject ChooseCar;
    // Start is called before the first frame update
    void Start()
    {
        if(gm == null)
        {
            gm = this;
        }
        ChooseCar.SetActive(false);
        state = GameState.Playing;
        Money = 1000;
        LeftTime = 60;

        for(int i=0; i<5; i++)
        {
            temp[i] = 0;
        }
    }
    public void GameBegin()
    {
        state = GameState.Playing;
    }
    public void GameWin()
    {
        Debug.Log("GameWin!");
    }
    public void GameFailed()
    {
        Debug.Log("GameFailed!");
    }
    public void TargetComplete(int i)
    {
        temp[i] = 1;
    }
    public void ArrivePoint(GameObject p)
    {
        Debug.Log("GameArrive" + p.name);
        //BeginRoll();
    }
    public void BeginRoll()
    {
        Debug.Log("GameBeginRoll");
    }
    public void UseMoney(float m)
    {
        Money -= m*5;
    }
    // Update is called once per frame
    void Update()
    {
        if (state == GameState.Playing)
        {
            moneyText.text = "Time:" + LeftTime.ToString();
            timeText.text = "Money" + Money.ToString();
            LeftTime -= Time.deltaTime;
            if (LeftTime <= 0 || Money <= 0)
                GameFailed();
        }

    }
}
