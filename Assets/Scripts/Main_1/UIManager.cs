using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject Player;
    private GameObject Target;
    public GameObject ChooseCar;

    public float SubwaySpeed;
    public float BusSpeed;
    public float TexiSpeed;
    public float WalkSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetTarget(GameObject t)
    {
        Target = t;
    }
    public void ChooseSubway()
    {
        Player.GetComponent<PlayMove>().PlayerMoveTo(Target, SubwaySpeed);
        ChooseCar.SetActive(false);
    }
    public void ChooseBus()
    {
        Player.GetComponent<PlayMove>().PlayerMoveTo(Target.gameObject, BusSpeed);
        ChooseCar.SetActive(false);
    }
    public void ChooseTexi()
    {
        Player.GetComponent<PlayMove>().PlayerMoveTo(Target.gameObject, TexiSpeed);
        ChooseCar.SetActive(false);
    }
    public void ChooseWalk()
    {
        Player.GetComponent<PlayMove>().PlayerMoveTo(Target.gameObject, WalkSpeed);
        ChooseCar.SetActive(false);
    }
   
}
