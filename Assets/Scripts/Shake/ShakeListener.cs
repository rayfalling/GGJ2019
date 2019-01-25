using System;
using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Shake{
    public class ShakeListener : MonoBehaviour{
        public float TotalTime = 10;

        float _delta = 0;
        int _count;
        private bool _timeover = false;
        Vector3 _last = Vector3.zero;

        void Start(){ }

        void FixedUpdate(){
            if (!_timeover) {
                _delta = Math.Max(Math.Max(_last.x - Input.acceleration.x, _last.y - Input.acceleration.y),
                    Math.Max(_last.z - Input.acceleration.z, _last.y - Input.acceleration.y));
                _last = Input.acceleration;
                if (_delta > 1.98f) {
                    _count++;
                }
            }

            if (TotalTime > 0.0f)
                TotalTime -= Time.fixedDeltaTime;
            else
                _timeover = true;
        }
    }
}