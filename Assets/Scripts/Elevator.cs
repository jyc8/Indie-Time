using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {
	public GameObject Target;
	private bool active = true;
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player" && active)
		{	
			Debug.Log ("Teleporting");
			Target.GetComponent<Elevator>().Deactivate();
			other.rigidbody2D.velocity = Vector2.zero;
			other.transform.position = Target.transform.position;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		active = true;
	}

	public void Deactivate(){
		active = false;
	}
}
