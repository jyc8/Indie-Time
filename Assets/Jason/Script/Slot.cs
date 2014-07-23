using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour {
	public bool isEmpty(){
		if(transform.childCount > 0)
		{
			return true;
		} else{
			return false;
		}
	}
}
