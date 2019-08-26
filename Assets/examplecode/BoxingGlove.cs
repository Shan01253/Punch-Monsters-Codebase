using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace examplecode
{
    public class BoxingGlove : MonoBehaviour
    {

        StateMachine SM = new StateMachine();
        // Start is called before the first frame update
        void Start()
        {
            SM.ChangeTo(new BGIdle_State(transform.position, transform, OnFinishIdle));
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SM.Execute();
            }
        }

        void OnFinishIdle()
        {
            Debug.Log("DoShit!");
            //SM.ChangeTo(new Party());
        }
    }

}
