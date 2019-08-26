using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace examplecode
{
    public class BGIdle_State : IState
    {
        
        Vector3 center;
        Transform t;
        Action callback;
        public BGIdle_State(Vector3 v, Transform t, Action callback)
        {
            center = v;
            this.t = t;
            this.callback = callback;
        }

        public void Enter()
        {
        }

        public void Execute()
        {
            t.RotateAround(center, 30);
            Collider2D[] c = Physics2D.OverlapCircleAll(t.position, 0.3f);
            if (c.Length > 0)
            {
                foreach (var coll in c)
                {
                    if (coll.gameObject.CompareTag("Wall"))
                    {
                        callback();
                    }

                }
            }
        }

        public void Exit()
        {
        }
    }
}

