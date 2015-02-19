using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour {

	public float size;
	public float deltaSize;

	public Transform spawn;
	public bool spawnAtStart;

	public float drag;
	public float swimSpeed;
	public float maxSpeed;
	
	// Control inputs
	public string upButton;
	public string downButton;
	public string rightButton;
	public string leftButton;
	
	// Used by camera for panning
	public bool isSpawned;
	
	private Vector2 velocity;
	private Vector3 deltaScale;
	private bool canMove;
	
	// for hiding and showing tooltip
	private CanvasGroup controlHint;
	private bool hinted = false;
	
	void Start() {
		canMove = false;
		isSpawned = false;
		velocity = Vector2.zero;
		deltaScale = new Vector3(deltaSize, deltaSize, 0.0f);
		controlHint = GetComponentInChildren<CanvasGroup>();
		
		if(spawnAtStart)
			Invoke("Spawn", 6.0f);
	}
	
	void Update () {
		if(canMove) {
			// Set x velocity
			if(Input.GetKey(rightButton))
				velocity.x += swimSpeed * Time.deltaTime * 10;
			else if(Input.GetKey(leftButton))
				velocity.x -= swimSpeed * Time.deltaTime * 10;
						
			// Set y velocity
			if(Input.GetKey(upButton))
				velocity.y += swimSpeed * Time.deltaTime * 10;
			else if(Input.GetKey(downButton))
				velocity.y -= swimSpeed * Time.deltaTime * 10;
			
			velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
			velocity.y = Mathf.Clamp(velocity.y, -maxSpeed, maxSpeed);
		}
		else {
			velocity = Vector2.zero;
		}
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
	
	public void Push(Vector2 force) {
		velocity += force;
	}
	
	public void Spawn() {
		transform.position = spawn.position;
		isSpawned = true;
		StartCoroutine(Grow ());
	}
	
	public void Kill() {
		if(canMove) {
			canMove = false;
			StartCoroutine(Shrink ());
		}
	}
	
	IEnumerator Grow() {
		while(transform.localScale.x < size) {
			transform.localScale += deltaScale * Time.deltaTime;
			yield return null;
		}
		transform.localScale = new Vector3(size, size, 1.0f);
		
		if(!hinted) {
			hinted = true;
			controlHint.SendMessage("Show");
		}
		canMove = true;
	}
	
	IEnumerator Shrink() {
		while(transform.localScale.x > 0) {
			transform.localScale -= deltaScale * Time.deltaTime;
			yield return null;
		}
		transform.localScale = new Vector3(0.0f, 0.0f, 1.0f);
		Spawn ();
	}
}
