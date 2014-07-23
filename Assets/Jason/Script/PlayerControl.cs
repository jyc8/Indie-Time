using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.

	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float jumpForce = 1000f;			// Amount of force added when the player jumps.

	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.

	// An object need to closer than that distance to be picked up.
	private Transform carriedObject = null;
	private int pickupLayer = 1 << 10; //Layer to pickup 10 is Music Objects
	private int slotsLayer = 1 << 11; //11 is Slots
	public float pickUpDist = 1f;	
	public GameObject attachObject;
	public float attachDistX = 0;
	public float attachDistY = 0;

	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();
	}


	void Update()
	{
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  

		// If the jump button is pressed and the player is grounded then the player should jump.
		if(Input.GetButtonDown("Jump") && grounded){
			jump = true;
		}

		if(Input.GetButtonDown("Action")) // Define it in the input manager
		{
			if(carriedObject == null){
				// Nothing in hand, we check if something is around and pick it up.
				PickUp();

			}else{
				Drop();
			}
		}

	}

	Transform findObject(float distance, int layer){
		Transform objectFound = null;
		// Collect every pickups around. Make sure they have a collider and the layer Pickup
		Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, distance, layer);
		
		// Find the closest
		float dist = Mathf.Infinity;
		for( int i = 0; i < objects.Length; i++ )
		{
			float newDist = (transform.position - objects[i].transform.position).sqrMagnitude;
			if( newDist < dist )
			{
				objectFound = objects[i].transform;
				dist = newDist;
			}
		}
		return objectFound;
	}

	void PickUp()
	{				
		carriedObject = findObject(pickUpDist, pickupLayer);
		if( carriedObject != null ) // Check if an item is found
		{
			Debug.Log("Picking");
			// Set the box on top of character
			Destroy(carriedObject.rigidbody2D);
			carriedObject.parent = attachObject.transform;
			carriedObject.localPosition = new Vector3( attachDistX, attachDistY, 1f ); //Attached Position
			carriedObject.localScale = new Vector3( 1f, 1f, 1f ); //Due to Unity -1 scale bug workaround, goddam annoying
			//Change Boolean
			carriedObject.GetComponent<MusicObject>().Activate();
		}
	}
	
	private void Drop()
	{
		Transform nearbySlot = findObject(pickUpDist, slotsLayer);
		if( nearbySlot != null ) // Check if a slotis found
		{
			Debug.Log("Slotting");
			carriedObject.parent = nearbySlot;
			carriedObject.localPosition = new Vector3( 0f, 1f, 1f); //Slotted Position
			if(!nearbySlot.GetComponent<Slot>().isEmpty()){

			} else{
			}
		}else{ //Do this if no slots are found
			Debug.Log("Dropping");
			carriedObject.localPosition = new Vector3( 1f, 0.5f, 1f ); 
			carriedObject.parent = null; // Unparenting
			carriedObject.gameObject.AddComponent( typeof(Rigidbody2D) ); // Gravity and co
			carriedObject.gameObject.rigidbody2D.mass = 20;
			carriedObject.gameObject.rigidbody2D.drag = 1.5f;
			carriedObject.localScale = new Vector3( 1f, 1f, 1f ); //Due to Unity -1 scale bug
		}
		carriedObject.GetComponent<MusicObject>().Deactivate();
		//Free Hands
		carriedObject = null;

	}

	void FixedUpdate ()
	{
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");

		// The Speed animator parameter is set to the absolute value of the horizontal input.
		anim.SetFloat("Speed", Mathf.Abs(h));

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * rigidbody2D.velocity.x < maxSpeed)
			// ... add a force to the player.
			rigidbody2D.AddForce(Vector2.right * h * moveForce);

		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

		// If the input is moving the player right and the player is facing left...
		if(h > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight)
			// ... flip the player.
			Flip();

		// If the player should jump...
		if(jump)
		{
			Jump();
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
	}

	void Jump(){
		// Set the Jump animator trigger parameter.
		anim.SetTrigger("Jump");
		
		// Play a random jump audio clip.
		int i = Random.Range(0, jumpClips.Length);
		AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);
		
		// Add a vertical force to the player.
		rigidbody2D.AddForce(new Vector2(0f, jumpForce));
	}

	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
