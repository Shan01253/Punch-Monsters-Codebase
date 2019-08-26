using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{

    IState Current;
    public void ChangeTo(IState s)
    {
        if (Current != null)
        {
            Current.Exit();
        }
        Current = s;
        Current.Enter();
    }

    public void Execute()
    {
        Current.Execute();
    }
}
