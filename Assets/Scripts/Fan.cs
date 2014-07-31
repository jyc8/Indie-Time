using UnityEngine;
using System.Collections;

public class Fan : MonoBehaviour {
	public float force = 10;
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player")
		{	
			Debug.Log ("Blowing");
			//other.rigidbody2D.AddRelativeForce(gameObject.transform.up*force, ForceMode2D.Impulse);
			other.rigidbody2D.velocity = Vector2.zero;
			other.rigidbody2D.AddForce(new Vector2(0f, 800));
		}
	}
}
