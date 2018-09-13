using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementInput : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler{

	PhoneTouchControls Parent;
	// Use this for initialization
	void Start () {
		Parent = GetComponentInParent<PhoneTouchControls> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (Input.GetTouch (0));
	}

	public void OnPointerClick(PointerEventData data){
		Debug.Log ("clicked");
	}

	public void OnPointerDown(PointerEventData data){
		Debug.Log ("Pointer Down");
		Parent.Touched (data);
	}

	public void OnPointerUp(PointerEventData data){
		Debug.Log ("Point Up");
		Parent.NoTouch ();
	}
}
