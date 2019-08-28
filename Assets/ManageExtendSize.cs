using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageExtendSize : MonoBehaviour
{
    public Transform Glove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.localScale = new Vector2((Glove.localPosition.x - transform.localPosition.x) - 1, 1);
    }
}
