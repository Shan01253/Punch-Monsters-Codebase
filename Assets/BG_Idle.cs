using UnityEngine;
using System;

namespace YahiyaScripts
{
    public class BG_Idle : IState
    {
        private Transform transform;
        private Action callback;


        private Camera cam;
        public BG_Idle(Transform transform, Action callback)
        {
            this.transform = transform;
            this.callback = callback;
        }

        public void Enter()
        {
            cam = Camera.main;
        }

        public void Execute()
        {
            rotateTowardsMouse();
            if (Input.GetMouseButtonDown(0))
            {
                callback();
            }
        }

        public void Exit()
        {
            
        }

        public void rotateTowardsMouse()
        {
            Vector3 v = (cam.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            v.z = 0;
            v = v.normalized;
            float angle = Mathf.Rad2Deg * Mathf.Atan2(v.y, v.x);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}