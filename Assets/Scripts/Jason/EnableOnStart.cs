using UnityEngine;
using System.Collections;

public class EnableOnStart : MonoBehaviour {
	public GameObject[] obj;
	
	void Start(){
		for (int i = 0; i < obj.Length; i++)
			obj[i].SetActive(true);
	}
}
