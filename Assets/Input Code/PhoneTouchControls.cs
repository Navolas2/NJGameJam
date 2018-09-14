using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhoneTouchControls : MonoBehaviour, TimeEvent {
	public UnityEngine.UI.Image Movement_Area;
	public CharacterController controller;


	private Touch movement;
	private Vector2 Starting_Position;
	private bool isTouched;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isTouched) {
			//If there is a touch happening it gets the movement from the initial position and sends that as the force input into the CharacterController
			if (movement.phase != TouchPhase.Ended && movement.phase != TouchPhase.Canceled) {
				//Debug.Log ("Moving");
				Vector2 movement_delta = Starting_Position - movement.position;
				float totalDelta = Mathf.Abs (movement_delta.x) + Mathf.Abs (movement_delta.y);
				float movementScale = 100 / totalDelta;
				//For some reason the input needs to be reversed. 
				movement_delta.x = movement_delta.x * movementScale * -1f;
				movement_delta.y = movement_delta.y * movementScale * -1f;

				controller.AddForce (movement_delta);
				TimeManager.manager.AddEvent (this);
			} else {
				isTouched = false;
				TimeManager.manager.RemoveEvent (this);
			}
		}
	}


	//The following functions are called by MovementInput when it is touched
	public void Touched(Touch location){
		movement = location;
		Starting_Position = movement.position;
		isTouched = true;
	}

	public void NoTouch(){
		isTouched = false;
		controller.RemoveVelocity ();
	}

	public bool TickEvent(){
		return false;
	}
}
