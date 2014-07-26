using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {
	protected Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(animator)
		{
			//get the current state
			//AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
			
			//if we're in "Run" mode, respond to input for jump, and set the Jump parameter accordingly. 
			//if(stateInfo.nameHash == Animator.StringToHash("Base Layer.RunBT"))
			//{
				if(Input.GetButton("Action")) {
					animator.SetBool("Pop", true );
			}
			else
			{
				animator.SetBool("Pop", false);                
			}
			
			//float h = Input.GetAxis("Horizontal");
			//float v = Input.GetAxis("Vertical");
			
			//set event parameters based on user input
			//animator.SetFloat("Speed", h*h+v*v);
			//animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);
		}       
	}        
}
