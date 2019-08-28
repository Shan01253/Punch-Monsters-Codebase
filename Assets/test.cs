using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YahiyasThrowaways
{
   
    public class test : MonoBehaviour
    {
        public float percent = 1;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            transform.localScale = Vector3.one * percent;
        }
    }
}
