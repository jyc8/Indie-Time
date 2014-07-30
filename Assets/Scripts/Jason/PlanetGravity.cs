using UnityEngine;
using System.Collections;

public class PlanetGravity : MonoBehaviour {
	public float gravStrength = 10;
	public GameObject planet;

	// Update is called once per frame
	void Update () {
		Vector2 planetVector = planet.transform.position - transform.position;
		rigidbody2D.AddForce(planetVector.normalized * gravStrength);
	}
}
