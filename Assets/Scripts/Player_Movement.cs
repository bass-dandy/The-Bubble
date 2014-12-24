using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

	public float drag;
	public float swimSpeed;
	public float maxSpeed;
	
	public string upButton;
	public string downButton;
	public string rightButton;
	public string leftButton;
	
	private Vector2 velocity;
	
	void Start() {
		velocity = Vector2.zero;
	}
	
	void Update () {
		// Set x velocity
		if(Input.GetKeyDown(rightButton))
			velocity.x += swimSpeed;
		else if(Input.GetKeyDown(leftButton))
			velocity.x -= swimSpeed;
						
		// Set y velocity
		if(Input.GetKeyDown(upButton))
			velocity.y += swimSpeed;
		else if(Input.GetKeyDown(downButton))
			velocity.y -= swimSpeed;
			
		velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
		velocity.y = Mathf.Clamp(velocity.y, -maxSpeed, maxSpeed);
			
		// Move the player
		rigidbody2D.velocity = velocity;
		
		// Decelerate x in two stages
		if(Mathf.Abs(velocity.x) > swimSpeed / 2)
			velocity.x = Mathf.Lerp(velocity.x, 0.0f, Time.deltaTime * drag);
		else
			velocity.x = Mathf.Lerp(velocity.x, 0.0f, Time.deltaTime * drag * 2);
		
		// Decelerate y in two stages
		if(Mathf.Abs(velocity.y) > swimSpeed / 2)
			velocity.y = Mathf.Lerp(velocity.y, 0.0f, Time.deltaTime * drag);
		else
			velocity.y = Mathf.Lerp(velocity.y, 0.0f, Time.deltaTime * drag * 2);
	}
}
