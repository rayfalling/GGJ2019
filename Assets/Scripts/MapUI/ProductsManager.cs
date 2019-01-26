using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductsManager : MonoBehaviour{
    public List<GameObject> Products;

    void Start(){ }

    void Update(){ }

    public void UpdateProductInfo(string productName, int count, Sprite icon){
        Products.Find(t => t.name == productName).GetComponent<ProductSync>().SetProductInfo("X" + count, icon);
    }

    public void UpdateProductCount(string productName, int count){
        Products.Find(t => t.name == productName).GetComponent<ProductSync>().UpdateProductCount("X" + count);
    }

    public void UpdateProductSprite(string productName, Sprite icon){
        Products.Find(t => t.name == productName).GetComponent<ProductSync>().UpdateProductSprite(icon);
    }
}