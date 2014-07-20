using UnityEngine;
using System.Collections;

public class MusicObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Activate(){
		Debug.Log("Music Object Activated");
		audio.Play();
	}

	public void Deactivate(){
		Debug.Log("Music Object Deactivated");
		StartCoroutine(FadeMusicOut());
	}

	IEnumerator FadeMusicOut(){
		for (float i = 9; i > 0; i--){
			audio.volume = audio.volume - audio.volume * 0.3f;
			yield return new WaitForSeconds (0.3f);
		}
		audio.Stop();
	}
}
