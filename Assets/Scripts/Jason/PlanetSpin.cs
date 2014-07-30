using UnityEngine;
using System.Collections;

public class PlanetSpin : MonoBehaviour {
	public GameObject planet;

	// Update is called once per frame
	void Start() {
		TriggerAllEvents();
	}

	void FixedUpdate() {
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");
		
		// If the input is moving the player right and the player is facing left...
		if(h > 0){
			Debug.Log("Moving Right");
		}else if(h < 0){
			Debug.Log("Moving Left");
		}
			
	}


	void PopChildren(Transform TriggerObject, bool Bool){
		//Debug.Log(TriggerObject.childCount);
		if (TriggerObject.childCount > 0){
			for (int i = 0; i < TriggerObject.childCount; i++){
				if (TriggerObject.GetChild(i).GetComponent<StateSelector>() != null){
					TriggerObject.GetChild(i).GetComponent<StateSelector>().Pop(Bool);
				}
				PopChildren(TriggerObject.GetChild(i), Bool);
			}
		}
	}
	
	void TriggerAllEvents(){
		PopChildren(transform, true);

	}
}
