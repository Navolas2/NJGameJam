using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : TimeAffectedObject {

	private Weapon myweapon;
	private CharacterController target;
	public int MaxVelocity = 6;
	private int orientation;

	// Use this for initialization
	void Start () {
		SetUp ();
		orientation = 0;
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!TimeCheck ()) {
			Vector2 target_location = target.transform.position;
			Vector2 my_location = transform.position;
			Vector2 direction = target_location - my_location;
			Vector2 distance = direction;

			direction.x = ((direction.x / 8) + 3) / ((direction.x * direction.x) + 1);
			direction.y = ((direction.y / 8) + 3) / ((direction.y * direction.y) + 1);
			rb2d.AddForce (direction);



			Vector2 current_Velocity = rb2d.velocity;

			float total = Mathf.Abs (current_Velocity.x) + Mathf.Abs (current_Velocity.y);
			if (total > MaxVelocity) {
				float movementScale = MaxVelocity / total;
				current_Velocity.x = current_Velocity.x * movementScale;
				current_Velocity.y = current_Velocity.y * movementScale;
				rb2d.velocity = current_Velocity;
			}

			orientation = CheckOrientation (rb2d.velocity);

			if (InRange (distance, target_location, my_location)) {
				if (Random.value < .75) {
					current_Velocity = current_Velocity / 2;
					rb2d.velocity = current_Velocity;
					//Attack
				}
			}
		}
	}

	/// <summary>
	/// Checks to see if the player is in the range of their attack
	/// </summary>
	/// <returns><c>true</c>, if range was ined, <c>false</c> otherwise.</returns>
	/// <param name="Distance">Distance.</param>
	bool InRange(Vector2 Distance, Vector2 target_location, Vector2 my_location){
		Vector2 weapRange = myweapon.OrientedRange (orientation);
		bool lateral = target_location.x > my_location.x - weapRange.x && target_location.x < my_location.x + weapRange.x;
		bool vert = target_location.y < my_location.y + weapRange.y && target_location.y > my_location.y;
		return lateral && vert;
	}

	/// <summary>
	/// Checks the orientation of the character using their velocity
	/// </summary>
	/// <returns>The orientation.</returns>
	/// <param name="velocity">Velocity.</param>
	int CheckOrientation(Vector2 velocity){
		if (velocity.x > velocity.y) {
			if (velocity.x > 0) {
				return 1;
			} else {
				return 3;
			}
		} else {
			if (velocity.y > 1) {
				return 0;
			} else {
				return 2;
			}
		}
	}
}
