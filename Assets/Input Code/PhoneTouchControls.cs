using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhoneTouchControls : MonoBehaviour {
	public UnityEngine.UI.Image Movement_Area;
	public CharacterController controller;


	private PointerEventData movement;
	private Vector2 Starting_Position;
	private bool isTouched;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isTouched) {
			Vector2 movement_delta = Starting_Position - movement.position;
			float totalDelta = Mathf.Abs (movement_delta.x) + Mathf.Abs (movement_delta.y);
			float movementScale = 100 / totalDelta;
			movement_delta.x = movement_delta.x * movementScale * -1f;
			movement_delta.y = movement_delta.y * movementScale * -1f;

			controller.AddForce (movement_delta);
		}
	}


	//The following functions are called by MovementInput when it is touched
	public void Touched(PointerEventData location){
		movement = location;
		Starting_Position = movement.position;
		isTouched = true;
	}

	public void NoTouch(){
		isTouched = false;
		controller.RemoveVelocity ();
	}
}
