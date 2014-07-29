using UnityEngine;
using System.Collections;

public class TriggerOnCollision : MonoBehaviour {
	private bool triggered = false;
	public bool triggerOnce = false;
	public bool audioTrigger = false;
	public bool loadLevel = false;
	public string level = "Scene Name";
	public bool pauseScript = false;
	public GameObject target;
	public string scriptName;
	public float time;
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
			if (pauseScript){
				target.GetComponent<scriptName>().enabled = false;
				StartCoroutine(TimeOut());
			}
			triggered = true;
		}

	}

	IEnumerator TimeOut(){
		for (float i = 5; i > 0; i--){
			audio.volume = audio.volume - audio.volume * 0.3f;
			yield return new WaitForSeconds (0.3f);
		}
		audio.Stop();
	}
}
