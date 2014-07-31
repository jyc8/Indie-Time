using UnityEngine;
using System.Collections;

public class PlanetSpin : MonoBehaviour {
	public GameObject planet;
	public GameObject musicMachine;
	public float speed = 0.5f;

	// Update is called once per frame
	void Start() {
		TriggerAllEvents();
	}

	void FixedUpdate() {
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");
		
		// If the input is moving the player right and the player is facing left...
		if(h > 0){
			//Debug.Log("Moving Right");
			transform.Rotate(Vector3.forward * speed);
		}else if(h < 0){
			//Debug.Log("Moving Left");
			transform.Rotate(Vector3.back * speed);
		}			
	}


	void PopChildrens(Transform TriggerObject, bool Bool){

		if (TriggerObject.childCount > 0){
			for (int i = 0; i < TriggerObject.childCount; i++){
				if (TriggerObject.GetChild(i).GetComponent<StateSelector>() != null){
					TriggerObject.GetChild(i).GetComponent<StateSelector>().Pop(Bool);
				}
				PopChildrens(TriggerObject.GetChild(i), Bool);
			}
		}
	}
	
	void TriggerAllEvents(){
		PopChildrens(transform, true);
	}
}
