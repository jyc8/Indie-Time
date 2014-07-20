using UnityEngine;
using System.Collections;

public class MusicObject : MonoBehaviour {
	bool fading = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Activate(){
		Debug.Log("Music Object Activated");
		fading = false;
		audio.Play();
		audio.volume = 1;
	}

	public void Deactivate(){
		Debug.Log("Music Object Deactivated");
		fading = true;
		StartCoroutine(FadeMusicOut());
	}

	IEnumerator FadeMusicOut(){
		for (float i = 5; i > 0; i--){
			audio.volume = audio.volume - audio.volume * 0.3f;
			yield return new WaitForSeconds (0.3f);
			if (!fading){
				break;
			}
		}
		if (fading){
			audio.Stop();
		}
	}
}
