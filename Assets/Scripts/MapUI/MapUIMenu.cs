using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUIMenu : MonoBehaviour{
    public GameObject ShowProducts;

    void Start(){
        GetComponent<Button>().onClick.AddListener(TogglePanel);
    }

    void Update(){ }

    void TogglePanel(){
        ShowProducts.SetActive(!ShowProducts.activeSelf);
    }
}