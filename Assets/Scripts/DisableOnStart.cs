using UnityEngine;
using System.Collections;

public class DisableOnStart : MonoBehaviour {
	public GameObject[] obj;

	void Start(){
		for (int i = 0; i < obj.Length; i++)
			obj[i].SetActive(false);
	}
}
