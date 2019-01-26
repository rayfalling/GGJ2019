using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImaneger : MonoBehaviour
{
    public GameObject[] images;
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    public void roll()
    {
        foreach(var p in images)
            p.GetComponent<Image>().color = Color.white;
        int index = Random.Range(0, images.Length);
        StartCoroutine("startroll", index);
    }
    IEnumerator startroll(int len)
    {
        for(int i=0;i<=len;i++)
        {
            images[i].GetComponent<Image>().color = Color.red;
            if(i>0)
                images[i-1].GetComponent<Image>().color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1);
        if (images[len].tag == "car")
            SceneManager.LoadScene("FCcar");
    }
}
