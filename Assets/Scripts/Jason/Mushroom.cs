using UnityEngine;
using System.Collections;

public class Mushroom : MonoBehaviour {
	public float bounceForce = 10;
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player")
		{	
			Debug.Log ("Bounce");
			other.rigidbody2D.AddForce(bounceForce * other.transform.up, ForceMode2D.Impulse);
		}
	}
}
