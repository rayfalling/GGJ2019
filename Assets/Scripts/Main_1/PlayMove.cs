using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class PlayMove : MonoBehaviour
{
    private float speed;

    public GameObject currentPoint;
=======
public class PlayMove : MonoBehaviour{
    public float speed;
    //public GameObject currentPoint;
>>>>>>> f13b58e6cf608ef62b73db51518c019f23ad0ca7

    private Vector2 pointpos;
    private Vector2 dir;

<<<<<<< HEAD
    private float timecount;
    private float timeused;
    public bool CanMoving;
    public bool isMapMoving;



    // Start is called before the first frame update
    void Start()
    {
        timecount = 0;
        timeused = 0;
=======
    private bool CanMoving;

    void Start(){
>>>>>>> f13b58e6cf608ef62b73db51518c019f23ad0ca7
        CanMoving = false;
        isMapMoving = false;
        pointpos = this.transform.position;
    }

    // Update is called once per frame
<<<<<<< HEAD
    void Update()
    {
        if(CanMoving)
        {
            //this.transform.position = Vector2.Lerp(this.transform.position, pointpos, Time.deltaTime);
            //this.transform.position = Vector2.LerpUnclamped(this.transform.position, pointpos, Time.deltaTime);
            this.transform.position = Vector3.MoveTowards(this.transform.position, pointpos, speed*Time.deltaTime);
            Vector2 v = (Vector2)this.transform.position - pointpos;

            timecount += Time.deltaTime;
            timeused += Time.deltaTime;

            if(timecount >= 0.2)
            {
                timecount = 0;
                int i = Random.Range(0, 10);
                if(i == 0)
                {
                    GameManagerMain.gm.BeginRoll();
                }
            }
            
            if (v.magnitude <= 0.01)
            {
                //Debug.Log("Arrive!!");
                GameManagerMain.gm.ArrivePoint(currentPoint);
                GameManagerMain.gm.UseMoney(timeused * speed * speed);
=======
    void Update(){
        if (CanMoving) {
            transform.position = Vector2.LerpUnclamped(transform.position, pointpos, Time.deltaTime);
            Vector2 v = (Vector2) this.transform.position - pointpos;
            if (v.magnitude <= 0.3) {
>>>>>>> f13b58e6cf608ef62b73db51518c019f23ad0ca7
                CanMoving = false;
            }
        }
    }
<<<<<<< HEAD
    public void PlayerMoveTo(GameObject point, float s)
    {
        
        if (!CanMoving && !isMapMoving)
        {
=======

    public void PlayerMoveTo(GameObject point){
        //currentPoint = point;
        if (!CanMoving) {
>>>>>>> f13b58e6cf608ef62b73db51518c019f23ad0ca7
            CanMoving = true;
            timeused = 0;
            timecount = 0;
            currentPoint = point;
            speed = s;
            pointpos = point.transform.position;
        }
    }
<<<<<<< HEAD
    public void StopMoving()
    {
        //Debug.Log("Arrive!");
=======

    public void StopMoving(){
>>>>>>> f13b58e6cf608ef62b73db51518c019f23ad0ca7
        CanMoving = false;
    }
}