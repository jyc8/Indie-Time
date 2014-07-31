using UnityEngine;
using System.Collections;

public class MusicMachine : MonoBehaviour {
	public GameObject BGMusicManager;
	public GameObject[] nature;
	public GameObject[] machine;


	void PopChildren(Transform TriggerObject, bool Bool){
		//Debug.Log(TriggerObject.childCount);
		if (TriggerObject.childCount > 0){
			for (int i = 0; i < TriggerObject.childCount; i++){
				if (TriggerObject.GetChild(i).GetComponent<StateSelector>() != null){
					TriggerObject.GetChild(i).GetComponent<StateSelector>().Pop(Bool);
				}
				PopChildren(TriggerObject.GetChild(i), Bool);
			}
		}
	}

	void TriggerEvents(int n, int m){
		for (int i = 0; i < n; i++){
			PopChildren(nature[i].transform, true);
		}
		for (int j = n; j < nature.Length; j++){
			PopChildren(nature[j].transform, false);
		}
		for (int i = 0; i < m; i++){
			PopChildren(machine[i].transform, true);
		}
		for (int j = m; j < machine.Length; j++){
			PopChildren(machine[j].transform, false);
		}
	}


	public void UpdateSlots(){
		int natureCount = 0;
		int machineCount = 0;
		for (int i = 0; i < transform.childCount; i++){
			Transform slot = transform.GetChild(i);
			if (slot.childCount == 1){
				slot.GetChild(0).GetComponent<MusicObject>().Activate();
				if (slot.GetChild(0).GetComponent<MusicObject>().isNature()){
					natureCount++;
				} else{
					machineCount++;
				}
			}
		}
		TriggerEvents(natureCount, machineCount);
		BGMusicManager.transform.GetComponent<BGMusicPlayer>().UpdateMusic();
	}

	public void TriggerAll(){
		PopChildren(nature[0].transform, true);
		PopChildren(machine[0].transform, true);
	}
}
