using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour{
    void Start(){
        GetComponent<Button>().onClick.AddListener(StartGame);
    }

    void StartGame(){
        Debug.Log("Game Start");
    }
}