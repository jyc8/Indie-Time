using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player")
		{	
			foreach(Collider2D collider in other.GetComponents<Collider2D>()){
				collider.enabled = false;
			}
			Debug.Log ("Bounce");
			//other.rigidbody2D.AddForce(bounceForce * other.transform.up, ForceMode2D.Impulse);
			other.rigidbody2D.velocity = Vector2.zero;
			other.rigidbody2D.AddForce(new Vector2(0f, 5000));
		}
	}
}
