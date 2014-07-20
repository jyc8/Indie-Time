using UnityEngine;

public class Player : MonoBehaviour
{
	// An object need to closer than that distance to be picked up.
	public float pickUpDist = 1f;
	
	private Transform carriedObject = null;
	private int pickupLayer = 1 << 10;
	
	private void Update()
	{
		if( Input.GetButton( "pickup" ) ) // Define it in the input manager
		{
			if( carriedObject != null ) // We're holding something already, we drop
				Drop();
			else // Nothing in hand, we check if something is around and pick it up.
				PickUp();
		}
	}
	
	private void Drop()
	{
		Debug.Log("Dropping");
		carriedObject.parent = null; // Unparenting
		//carriedObject.gameObject.AddComponent( typeof(Rigidbody) ); // Gravity and co
		carriedObject = null; // Hands are free again
	}
	
	private void PickUp()
	{
		Debug.Log("Picking");
		// Collect every pickups around. Make sure they have a collider and the layer Pickup
		Collider2D[] pickups = Physics2D.OverlapCircleAll( transform.position, pickUpDist, pickupLayer );
		
		// Find the closest
		float dist = Mathf.Infinity;
		for( int i = 0; i < pickups.Length; i++ )
		{
			float newDist = (transform.position - pickups[i].transform.position).sqrMagnitude;
			if( newDist < dist )
			{
				carriedObject = pickups[i].transform;
				dist = newDist;
			}
		}
		
		if( carriedObject != null ) // Check if we found something
		{
			// Set the box in front of character
			//Destroy( carriedObject.rigidbody );
			carriedObject.parent = transform;
			carriedObject.localPosition = new Vector3( 0, 1f, 1f ); // Might need to change that
		}
	}
}