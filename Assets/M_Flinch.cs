using System;
using UnityEngine;

internal class M_Flinch : IState
{
    private float flinchTime;
    private Action callback;

    public M_Flinch(float flinchTime, Action callback)
    {
        this.flinchTime = flinchTime;
        this.callback = callback;
    }
    float startTime;
    public void Enter()
    {
        Debug.Log("flinch");

        startTime = Time.time;
    }

    public void Execute()
    {
        if (Time.time - startTime > flinchTime)
        {
            callback();
        }
    }

    public void Exit()
    {
    }
}