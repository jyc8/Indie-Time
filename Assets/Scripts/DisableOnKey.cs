﻿using UnityEngine;
using System.Collections;

public class DisableOnKey : MonoBehaviour {
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			this.gameObject.SetActive(false);
		}
	}
}
