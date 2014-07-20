using UnityEngine;
using System.Collections;

public class MusicObject : MonoBehaviour {
	public bool pickedUp = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (pickedUp) {

		}
	}

	public void Activate(){
		Debug.Log("Music Object Activated");
		audio.Play();
	}

	public void Deactivate(){
		Debug.Log("Music Object Deactivated");
		audio.Stop();
	}
}
