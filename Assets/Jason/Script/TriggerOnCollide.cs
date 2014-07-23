using UnityEngine;
using System.Collections;

public class TriggerOnCollide : MonoBehaviour {
	public string level = "Scene Name"; 

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("Something has entered this zone.");
		Application.LoadLevel(level);
	} 
}
