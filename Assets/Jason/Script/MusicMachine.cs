using UnityEngine;
using System.Collections;

public class MusicMachine : MonoBehaviour {
	public void UpdateSlots(){
		for (int i = 0; i < transform.childCount; i++){
			Transform slot = transform.GetChild(i);
			if (slot.childCount > 0){
				slot.GetChild(0).GetComponent<MusicObject>().Activate();
			}
		}
	}
}
