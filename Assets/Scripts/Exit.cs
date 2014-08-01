using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	void Update (){
		if (Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
		if (Input.GetKeyDown(KeyCode.Alpha1)){
			Application.LoadLevel("Level 1");
		}	
		if (Input.GetKeyDown(KeyCode.Alpha2)){
			Application.LoadLevel("Level 2");
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)){
			Application.LoadLevel("Level 3");
		}	
		if (Input.GetKeyDown(KeyCode.Alpha4)){
			Application.LoadLevel("Level 4");
		}
		if (Input.GetKeyDown(KeyCode.Alpha5)){
			Application.LoadLevel("Level 5 End");
		}
	}
}