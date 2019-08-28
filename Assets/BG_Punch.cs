using UnityEngine;
using System;

namespace YahiyaScripts
{
    internal class BG_Punch : IState
    {
        private Animator anim;
        private ExtendoDefense ED;
        private Transform transform;
        private Transform Glove;
        private Vector3 target;
        //will be called by Animator when it finishes animation
        public static Action<bool> callback;
        private float distance;

        private static bool QueuedTarget = false;
        private Camera cam;



        public BG_Punch(Animator anim, Transform transform, Transform Glove, ExtendoDefense ED, Action<bool> callback)
        {
            this.anim = anim;
            this.ED = ED;
            BG_Punch.callback = callback;
            this.transform = transform;
            this.Glove = Glove;
        }

        public void Enter()
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
            anim.SetTrigger("punch");
            distance = (target - transform.position - Vector3.right * 2).magnitude;
            if (distance > ED.MaximumPunchDistance)
                distance = ED.MaximumPunchDistance;
            cam = Camera.main;
        }

        public void Execute()
        {

            Glove.localPosition = Vector3.right * (2 + ED.percentToTarget * distance);

            if (Input.GetMouseButtonDown(0))
            {
                QueuedTarget = true;
            }
        }

        public void Exit()
        {
        }

        public static void ForceCallback()
        {
            callback(QueuedTarget);
        }
    }
}