using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YahiyaScripts
{
    public class ExtendoDefense : MonoBehaviour
    {
        Camera cam;
        public float percentToTarget = 0;
        public float MaximumPunchDistance = 5;
        public Transform GloveDestination;
        Vector3 v = Vector3.zero;
        StateMachine machine = new StateMachine();
        Animator anim;
        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
            machine.ChangeTo(new BG_Idle(transform, OnclickCallback));
            cam = Camera.main;
        }
        public void OnclickCallback()
        {
            Debug.Log("Clicked!");
            machine.ChangeTo(new BG_Punch(anim, transform, GloveDestination, this, OnFinishedPunchingCallback));
        }

        public void OnFinishedPunchingCallback(bool queuedHit)
        {
            Debug.Log("Successfully completed punch!");
            //if (queuedHit)
            //{
            //    machine.ChangeTo(new BG_Punch(anim, transform, GloveDestination, this, OnFinishedPunchingCallback));
            //}
            machine.ChangeTo(new BG_Idle(transform, OnclickCallback));
        }
        // Update is called once per frame
        void Update()
        {
            machine.Execute();

            //if (Input.GetMouseButtonDown(0))
            //{
            //    //rotateTowardsMouse();
            //    Vector3 v = cam.ScreenToWorldPoint(Input.mousePosition);
            //    v.z = 0;
            //    GloveDestination.position = v;

            //}
        }

        //private void OnDrawGizmos()
        //{
        //    Gizmos.DrawWireSphere(v, 0.1f);
        //}

        //public void rotateTowardsMouse()
        //{
        //    v = (cam.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        //    v.z = 0;
        //    v = v.normalized;
        //    float angle = Mathf.Rad2Deg * Mathf.Atan2(v.y, v.x);
        //    Debug.Log(angle);
        //    transform.rotation = Quaternion.Euler(0, 0, angle);
        //}
    }
    
}

