using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YahiyasThrowaways
{
    
    public class moveforward : MonoBehaviour
    {
        bool toggle = true;
        // Start is called before the first frame update
        void Start()
        {

        }
        
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                toggle = !toggle;

            }
            if (toggle)
                GetComponent<Rigidbody2D>().velocity = Vector2.right;
        }
    }
}


