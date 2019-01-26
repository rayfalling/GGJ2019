using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductSync : MonoBehaviour{
    public Image ProductIcon;
    public TextMeshProUGUI Number;
    public string ProductName;
    void Start(){ }

    // Update is called once per frame
    void Update(){ }

    public void SetProductInfo(string text, Sprite icon){
        Number.GetComponent<TextMeshProUGUI>().text = text;
        ProductIcon.sprite = icon;
    }

    public void UpdateProductCount(string count){
        Number.GetComponent<TextMeshProUGUI>().text = count;
    }

    public void UpdateProductSprite(Sprite icon){
        ProductIcon.sprite = icon;
    }
}