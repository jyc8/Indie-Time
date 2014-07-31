using UnityEngine;
using System.Collections;

public class EnableOnStart : MonoBehaviour {
	public GameObject[] obj;
	public bool end = false;
	public int stage;
	private int positive = 0;
	private int negative = 0;
	
	void Start(){
		if (end){
			for (int i = 0; i < stage; i++){
				if (GlobalVariable.Positive[i] == true){
					positive++;
				}else {
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
		//Debug
		//negative = 2;
		//positive = 2;
		//End Debug
		if (negative > positive){
			obj[0].SetActive(true);
		}
		if (positive > negative){
			obj[1].SetActive(true);
		}
		if (positive == negative){
			obj[2].SetActive(true);
		}
	}
}
