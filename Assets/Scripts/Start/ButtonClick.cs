using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour{
    void Start(){
        GetComponent<Button>().onClick.AddListener(StartGame);
    }

    void StartGame(){
        SceneManager.LoadScene("Main");
        Debug.Log("Game Start");
    }
}