using UnityEngine;
using System.Collections;

public class Mushroom : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player")
		{	
			Debug.Log ("Bounce");
			//other.rigidbody2D.AddForce(bounceForce * other.transform.up, ForceMode2D.Impulse);
			other.rigidbody2D.velocity = Vector2.zero;
			other.rigidbody2D.AddForce(new Vector2(0f, 1500));
		}
	}
}
