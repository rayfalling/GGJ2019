using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{
    public float TotalTime = 10;
    public GameObject Label;
    public GameObject Ball;

    bool _ifGameOver = false;

    // Start is called before the first frame update
    void Start(){ }

    // Update is called once per frame
    void Update(){
        if (!_ifGameOver) TotalTime -= Time.deltaTime;
        if (TotalTime <= 0.0f) {
            _ifGameOver = true;
            TotalTime = 0.0f;
            Ball.SetActive(false);
        }

        Label.GetComponent<TextMeshProUGUI>().text = TotalTime.ToString("F2");
    }

    public void GameOver(){
        _ifGameOver = true;
        Ball.SetActive(false);
    }
}