using UnityEngine;
using System.Collections;

public class BGMusicPlayer : MonoBehaviour {
	public int Stage;
	// Use this for initialization
	void Start () {
		/*Debug
		GlobalVariable.Positive[0] = true;
		GlobalVariable.Positive[1] = false;
		GlobalVariable.Positive[2] = false;
		GlobalVariable.Positive[3] = true;
		*/
		PlayMusic();
	}

	void PlayMusic(){
		for (int i = 0; i < Stage; i++){
			if (GlobalVariable.Positive[i] == true){
				Debug.Log ("Playing Positive " + i);
				transform.GetChild(0).GetChild(i).audio.Play();
			}else {
				Debug.Log ("Playing Negative " + i);
				transform.GetChild(1).GetChild(i).audio.Play();
			}
		}
	}

	public void UpdateMusic(){
		PlayMusic();
	}
}
