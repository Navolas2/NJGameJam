using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
	Rigidbody2D rb2d;
	public float MaxVelocity = 20;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//rb2d.AddForce (new Vector2(Input.GetAxis ("Horizontal"), 0));
	}

	public void AddForce(Vector2 force){
		rb2d.AddForce (force);

		Vector2 current_Velocity = rb2d.velocity;

		float total = Mathf.Abs (current_Velocity.x) + Mathf.Abs (current_Velocity.y);
		if (total > MaxVelocity) {
			float movementScale = MaxVelocity / total;
			current_Velocity.x = current_Velocity.x * movementScale;
			current_Velocity.y = current_Velocity.y * movementScale;
			rb2d.velocity = current_Velocity;
		}
	}

	public void RemoveVelocity(){
		rb2d.velocity = new Vector2 ();
	}
}
