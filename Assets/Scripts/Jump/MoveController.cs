using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveController : MonoBehaviour{
    public float MoveSpeed = 8.0f;
    public Camera Camera;

    private bool cross = false;

    private float deltaTime = 0;

    // Start is called before the first frame update
    void Start(){ }

    // Update is called once per frame
    void Update(){
        var vector = Vector3.zero;
        if (Math.Abs(Input.acceleration.x) > 0.1f)
            vector.x = Math.Abs(Input.acceleration.x) >= 0.3
                ? (Input.acceleration.x < 0 ? -0.3f : 0.3f)
                : Input.acceleration.x;
        if (vector.sqrMagnitude > 1)
            vector.Normalize();
        vector *= Time.deltaTime;
        transform.Translate(vector * MoveSpeed);
        if (cross) deltaTime += Time.deltaTime;
        if (deltaTime > 0.3f) cross = false;
        if (!cross && Math.Abs(transform.localPosition.x) > (Camera.orthographicSize + 1) / 2) {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
            deltaTime = 0;
            cross = true;
        }
    }
}