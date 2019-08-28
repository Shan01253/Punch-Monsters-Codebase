using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexCode {

public class EnemyBehavior : MonoBehaviour
{
	public GameObject target;	

	private StateMachine enStateMachine;
	private Rigidbody2D rb;


	public void testCallback() {
		Debug.Log("Callback reached.");
	}

	// Start is called before the first frame update
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();

		enStateMachine = new StateMachine();
		enStateMachine.ChangeTo(new EnAI_Approach(target, rb, testCallback)); 
	}

	// Update is called once per frame
	void Update()
	{
		enStateMachine.Execute();
	}
}

}
