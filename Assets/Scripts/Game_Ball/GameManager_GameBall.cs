using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_GameBall : MonoBehaviour
{
    enum GameState {Begin, Playing, Win, Failed};
    private GameState State;

    public static GameManager_GameBall gm;
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    // Start is called before the first frame update
    void Start()
    {
        State = GameState.Begin;
        if(gm == null)
        {
            gm = this;
        }
    }
    public bool IsPlaying()
    {
        if (State == GameState.Playing)
            return true;
        else
            return false;
    }
    public void GameWin()
    {
        State = GameState.Win;
        Debug.Log("GameWin");
    }
    public void GameFailed(float time)
    {
        State = GameState.Failed;
        Debug.Log("GameFailed,TimeUsed: " + time.ToString());
    }
    public void GameBegin()
    {
        State = GameState.Playing;
        Debug.Log("Start!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
