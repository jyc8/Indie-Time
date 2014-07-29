using UnityEngine;
using System.Collections;

public class TriggerOnCollision : MonoBehaviour {
	private bool triggered = false;
	public bool triggerOnce = false;
	public bool audioTrigger = false;
	public bool loadLevel = false;
	public string level = "Scene Name";
	public bool warp = false;
	public float warpDistance;
	public float warpHeight;


	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("Something has entered this zone.");
		if (triggerOnce == true && triggered == true){
			
		} else{
			if (loadLevel){
				Application.LoadLevel(level);
			}
			if (warp){
				Debug.Log("Warping.");
				other.gameObject.transform.localPosition = new Vector3( other.gameObject.transform.position.x + warpDistance, warpHeight, 1f );
			}
			if (audioTrigger){
				audio.Play();
			}
			triggered = true;
		}

	} 
}
