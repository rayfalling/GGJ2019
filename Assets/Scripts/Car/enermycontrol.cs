using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enermycontrol : MonoBehaviour{
    private List<GameObject> enermys;
    public GameObject enerm;
    private float _timer;
    private float _totaltime;

    public GameObject ground;

    // Start is called before the first frame update
    void Start(){
        enermys = new List<GameObject>();
        _totaltime = _timer = 0;
    }

    // Update is called once per frame
    void Update(){
        _totaltime += Time.deltaTime;
        _timer += Time.deltaTime;
        if (_timer >= Random.Range(1f, 2.5f) && GameObject.Find("grounds").GetComponent<background>().isstop == false) {
            int i = (int) Random.Range(1f, 0.2f * _totaltime + 1);
            for (int j = 0; j < i; j++) {
                GameObject go = Instantiate(enerm, new Vector2(Random.Range(-2.02f, 2.02f), 5.54f),
                    Quaternion.identity);
                go.transform.parent = ground.transform;
                enermys.Add(go);
            }

            _timer = 0;
        }

        if (enermys.Count > 0) {
            for (int i = 0; i < enermys.Count; i++) {
                //enermys[i].transform.Translate(Vector2.up * -0.2f * enspeed * Time.deltaTime * totaltime);
                if (enermys[i].transform.position.y <= -3) {
                    GameObject p = enermys[i];
                    enermys.Remove(p);
                    Destroy(p);
                }
            }
        }

        if (_totaltime >= 15) //成功
        {
            Time.timeScale = 0;
            _totaltime = 0;
        }
    }
}