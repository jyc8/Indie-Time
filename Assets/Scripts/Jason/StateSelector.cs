using UnityEngine;
using System.Collections;

public class StateSelector : MonoBehaviour {
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
			if(Input.GetButton("Action")) {
				//Pop ();
			}
			if(Input.GetButton("Jump")){
				animator.SetBool("Pop", false );
			}
		}       
	}        

	public void Pop(bool Bool){
		animator.SetBool("Pop", Bool);
	}
}
