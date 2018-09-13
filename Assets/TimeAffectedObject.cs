using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAffectedObject : MonoBehaviour {

	Rigidbody2D rb2d;
	private Vector2 MovingVelocity;
	private float gravity;
	private bool paused;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		gravity = rb2d.gravityScale;
		MovingVelocity = rb2d.velocity;
	}
	
	// Update is called once per frame
	void Update () {
		if (paused && TimeManager.manager.IsTimeMoving ()) {
			Debug.Log ("Move "  + Time.time.ToString());
			rb2d.gravityScale = gravity;
			rb2d.velocity = MovingVelocity;
			paused = false;
		}
		else if (!TimeManager.manager.IsTimeMoving () && !paused) {
			Debug.Log ("Stop "  + Time.time.ToString());
			gravity = rb2d.gravityScale;
			MovingVelocity = rb2d.velocity;
			rb2d.gravityScale = 0;
			rb2d.velocity = new Vector2 ();
			paused = true;
		}
	}
}
