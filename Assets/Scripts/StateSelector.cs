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
		/* Debug Scripts
		if(animator)
		{
			if(Input.GetButton("Action")) {
				Pop(true);
			}
			if(Input.GetButton("Jump")){
				Pop(false);
			}
		}       
		*/
	}        

	public void Pop(bool Bool){
		animator.SetBool("Pop", Bool);
	}
}
