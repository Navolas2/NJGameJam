using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterController : MonoBehaviour, TimeEvent {
	Rigidbody2D rb2d;
	public float MaxVelocity = 20;
	private int jumpCount = 0;
	public UnityEngine.UI.Text TextBox;
	private Vector2 PriorVelocity;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	//	float horizontal = CrossPlatformInputManager.GetAxis ("Horizontal");
	//	float vertical = CrossPlatformInputManager.GetAxis ("Vertical");

		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		Vector2 force = new Vector2 (horizontal, vertical);

		if (horizontal != 0 || vertical != 0) {
			if (!TimeManager.manager.EventExist (this)) {
				TimeManager.manager.AddEvent (this);
				float vel = Mathf.Sqrt (Mathf.Pow (PriorVelocity.x, 2) + Mathf.Pow (PriorVelocity.y, 2));
				Vector2 new_vel = new Vector2 (force.x * vel, force.y * vel);
				Debug.Log (PriorVelocity.ToString () + " -> " + force.ToString() + " " + new_vel.ToString ());
				rb2d.velocity = new_vel;
			}
			TextBox.text = "Move";
			rb2d.AddForce (force);
			Debug.Log (force.ToString ());

			Vector2 current_Velocity = rb2d.velocity;

			float total = Mathf.Abs (current_Velocity.x) + Mathf.Abs (current_Velocity.y);
			if (total > MaxVelocity) {
				float movementScale = MaxVelocity / total;
				current_Velocity.x = current_Velocity.x * movementScale;
				current_Velocity.y = current_Velocity.y * movementScale;
				rb2d.velocity = current_Velocity;
			}

		} else {
			if (TimeManager.manager.EventExist (this)) {
				TextBox.text = "Stop";
				//Debug.Log ("Stopping " + Time.time.ToString ());
				RemoveVelocity ();
				TimeManager.manager.RemoveEvent (this);
			}
		}
		if (CrossPlatformInputManager.GetButtonDown ("Jump")) {
			jumpCount++;
			//TextBox.text = jumpCount.ToString ();
		}
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
		PriorVelocity = rb2d.velocity;
		rb2d.velocity = new Vector2 ();
	}

	public bool TickEvent(){
		return false;
	}
}
