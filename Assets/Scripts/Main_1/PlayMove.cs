using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMove : MonoBehaviour{
    public float speed;
    //public GameObject currentPoint;

    private Vector2 pointpos;
    private Vector2 dir;

    private bool CanMoving;

    void Start(){
        CanMoving = false;
        pointpos = this.transform.position;
    }

    // Update is called once per frame
    void Update(){
        if (CanMoving) {
            transform.position = Vector2.LerpUnclamped(transform.position, pointpos, Time.deltaTime);
            Vector2 v = (Vector2) this.transform.position - pointpos;
            if (v.magnitude <= 0.3) {
                CanMoving = false;
            }
        }
    }

    public void PlayerMoveTo(GameObject point){
        //currentPoint = point;
        if (!CanMoving) {
            CanMoving = true;
            pointpos = point.transform.position;
        }
    }

    public void StopMoving(){
        CanMoving = false;
    }
}