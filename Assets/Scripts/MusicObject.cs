﻿using UnityEngine;
using System.Collections;

public class MusicObject : MonoBehaviour {
	bool fading = false;
	public bool nature = false;

	public bool isNature(){
		return nature;
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
