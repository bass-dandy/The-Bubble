using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

	public float accelX;
	public float decelX;
	public float maxVelX;
	public float jumpForce;
	
	public string jumpButton;
	public string rightButton;
	public string leftButton;
	
	
	void Update () {
		// Move horizontally
		if(Input.GetKey(rightButton)) {
			if(rigidbody2D.velocity.x < 0 && rigidbody2D.velocity.y == 0)
				rigidbody2D.velocity = new Vector2(maxVelX, rigidbody2D.velocity.y);
			else	
				rigidbody2D.AddForce(new Vector2(accelX * Time.deltaTime, 0));
		}
		else if(Input.GetKey(leftButton)) {
			if(rigidbody2D.velocity.x > 0 && rigidbody2D.velocity.y == 0)
				rigidbody2D.velocity = new Vector2(-maxVelX, rigidbody2D.velocity.y);
			else
				rigidbody2D.AddForce(new Vector2(-1 * accelX * Time.deltaTime, 0));
		}
			
		// Decelerate in two stages
		else if (rigidbody2D.velocity.y == 0) {
			if(Mathf.Abs(rigidbody2D.velocity.x) > maxVelX / 2)
				rigidbody2D.velocity = new Vector2(Mathf.Lerp(rigidbody2D.velocity.x, 0.0f, Time.deltaTime * decelX), rigidbody2D.velocity.y);
			else
				rigidbody2D.velocity = new Vector2(Mathf.Lerp(rigidbody2D.velocity.x, 0.0f, Time.deltaTime * decelX * 2), rigidbody2D.velocity.y);
		}
			
		// Move vertically
		if(Input.GetKeyDown(jumpButton) && rigidbody2D.velocity.y == 0)
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
			
		// Clamp velocity
		float velX = Mathf.Clamp(rigidbody2D.velocity.x, -maxVelX, maxVelX);
		rigidbody2D.velocity = new Vector2(velX, rigidbody2D.velocity.y);
	}
}
