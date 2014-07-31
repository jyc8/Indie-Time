using UnityEngine;
using System.Collections;

public class EnableOnStart : MonoBehaviour {
	public GameObject[] obj;
	public bool end = false;
	private int positive = 0;
	private int negative = 0;
	
	void Start(){
		if (end){
			for (int i = 0; i < 4; i++){
				if (GlobalVariable.Positive[i] == true){
					positive++;
				}else {
					Debug.Log ("Playing Negative " + i);
					negative++;
				}
			}
			EnableGlobe();
		}else{
			for (int i = 0; i < obj.Length; i++){
				obj[i].SetActive(true);
			}
		}
	}

	void EnableGlobe(){
		if (negative > positive){
			obj[0].SetActive(true);
		}
	}
}
