using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour{
    public List<GameObject> Points;

    public GameObject CurrentPoints;
    GameObject _destination;
    private Vector3 _pointpos;
    private bool _moving = true;

    void Start(){
        if (CurrentPoints != null)
            transform.position = CurrentPoints.transform.position;
        else {
            _destination = GetComponent<Points>().NextPoint[Random.Range(0, GetComponent<Points>().NextPoint.Count)];
            _pointpos = _destination.transform.position;
        }
    }

    // Update is called once per frame
    void Update(){
        if (_moving) {
            transform.position = Vector3.LerpUnclamped(transform.position, _pointpos, Time.deltaTime);
            Vector2 v = transform.position - _pointpos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        CurrentPoints = GameObject.Find(collision.name);
        _destination = CurrentPoints.GetComponent<Points>()
                                    .NextPoint[Random.Range(0, CurrentPoints.GetComponent<Points>().NextPoint.Count)];
        _pointpos = _destination.transform.position;
    }
}