using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace AlexCode {

public class EnAI_Approach : IState
{
	protected GameObject target;
	protected Rigidbody2D rb;
	public static Action callback;

	// I think C# has a better way of handling this, but idk
	public EnAI_Approach(GameObject target, Rigidbody2D rb, Action callback) {
		this.rb = rb;
		this.target = target;
		EnAI_Approach.callback = callback;
	}

	public void Enter() {
		// nothing
	}

	// have 
	public void Execute() {
		Debug.Log("Running Approach AI");
	}

	public void Exit() {
		// nothing
	}
}

}
