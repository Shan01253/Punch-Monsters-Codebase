using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace YahiyasThrowaways
{
    public class switchMode : MonoBehaviour
    {
        public float speed = 150;
        HingeJoint2D HJ;
        // Start is called before the first frame update
        void Start()
        {
            HJ = GetComponent<HingeJoint2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("space");
                float f = HJ.motor.motorSpeed * -1 * speed;
                JointMotor2D M = HJ.motor;
                M.motorSpeed = f;
                HJ.motor = M;
            }
        }
    }
}

