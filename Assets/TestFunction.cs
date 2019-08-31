using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestFunction : MonoBehaviour
{
    public event Action Listeners;
    // Start is called before the first frame update
    void Start()
    {
        Listeners += test;
        Listeners += test;
        Listeners += test;
        Listeners += test;
        Listeners += test;
    }

    // Update is called once per frame
    void test()
    {

    }

    private void Update()
    {
        Listeners?.Invoke();
    }


}
