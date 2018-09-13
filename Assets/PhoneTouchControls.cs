using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhoneTouchControls : MonoBehaviour {
	public UnityEngine.UI.Image Movement_Area;

	private PointerEventData movement;
	private Vector2 Starting_Position;
	private bool isTouched;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		while (isTouched) {
			Vector2 movement_delta = Starting_Position - movement.position;
			Debug.Log (movement_delta);
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
	}
}
