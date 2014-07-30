using UnityEngine;
using System.Collections;

public class TriggerOnCollision : MonoBehaviour {
	private bool triggered = false;
	public bool triggerOnce = false;
	public bool setActiveTrigger = false;
	public GameObject target;
	public bool audioTrigger = false;
	public bool loadLevel = false;
	public bool positive = false;
	public int currentLevelNumber;
	public string levelName = "Scene Name";
	public bool pauseMovement = false;
	public GameObject Player;
	public float time;
	public bool warp = false;
	public float warpDistance;
	public float warpHeight;


	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("Something has entered this zone.");
		if (triggerOnce == true && triggered == true){
			
		} else{
			if (loadLevel){
				GlobalVariable.Positive[currentLevelNumber] = positive;
				Application.LoadLevel(levelName);
			}
			if (warp){
				Debug.Log("Warping.");
				other.gameObject.transform.localPosition = new Vector3( other.gameObject.transform.position.x + warpDistance, warpHeight, 1f );
			}
			if (audioTrigger){
				audio.Play();
			}
			if (setActiveTrigger){
				target.SetActive(true);
				if(time > 0){
					StartCoroutine(LifeTime());
				}
			}
			if (pauseMovement){
				Player.GetComponent<PlayerControl>().enabled = false;
				Player.GetComponent<Animator>().enabled = false;
				StartCoroutine(TimeOut());
			}
			triggered = true;
		}

	}

	IEnumerator TimeOut(){
		yield return new WaitForSeconds (time);
		Player.GetComponent<PlayerControl>().enabled = true;
		Player.GetComponent<Animator>().enabled = true;
	}

	IEnumerator LifeTime(){
		yield return new WaitForSeconds (time);
		target.SetActive(false);
	}
}
