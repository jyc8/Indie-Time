﻿using UnityEngine;
using System.Collections;

public class MusicMachine : MonoBehaviour {
	public GameObject[] nature;
	public GameObject[] machine;

	void TriggerEvents(int n, int m){
		for (int i = 0; i < n; i++){
			if (nature[i] != null){
				nature[i].SetActive(true);
			}
		}
		for (int j = n; j < nature.Length; j++){
			if (nature[j] != null){
				nature[j].SetActive(false);
			}
		}
		for (int i = 0; i < m; i++){
			if (machine[i] != null){
				machine[i].SetActive(true);
			}
		}
		for (int j = m; j < machine.Length; j++){
			if (machine[j] != null){
				machine[j].SetActive(false);
			}
		}
	}

	public void UpdateSlots(){
		int natureCount = 0;
		int machineCount = 0;
		for (int i = 0; i < transform.childCount; i++){
			Transform slot = transform.GetChild(i);
			if (slot.childCount > 0){
				slot.GetChild(0).GetComponent<MusicObject>().Activate();
				if (slot.GetChild(0).GetComponent<MusicObject>().isNature()){
					natureCount++;
				} else{
					machineCount++;
				}
			}
		}
		TriggerEvents(natureCount, machineCount);
	}
}
