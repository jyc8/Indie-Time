using UnityEngine;
using System.Collections;

public class PlanetSpin : MonoBehaviour {
	public GameObject planet;
	public GameObject musicMachine;
	public float speed = 0.5f;

	// Update is called once per frame
	void Start() {
		musicMachine.GetComponent<MusicMachine>().TriggerAll();
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
}
