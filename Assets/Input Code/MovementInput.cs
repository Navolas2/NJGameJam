using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementInput : MonoBehaviour,  ISelectHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler{

	public UnityEngine.UI.Text TextBox;
	PhoneTouchControls Parent;
	// Use this for initialization
	void Start () {
		Parent = GetComponentInParent<PhoneTouchControls> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			//Gets the Input from touch. If Touch is touching the box it passes the touch information to the PhoneTouchControls
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				Touch t = Input.GetTouch (Input.touchCount - 1);
				int pointer_ID = t.fingerId;
				bool res = EventSystem.current.IsPointerOverGameObject (pointer_ID);
				if (res) {
					TextBox.text = "moving";
					Parent.Touched (t);
				} else {
					TextBox.text = "not moving";
				}
			}
		}
	}

	public void OnSelect(BaseEventData eventData){
		TextBox.text = "I am touched";
	}



	public void OnPointerClick(PointerEventData data){
	}

	public void OnPointerDown(PointerEventData data){
		//Parent.Touched (data);
	}

	public void OnPointerUp(PointerEventData data){
		Debug.Log ("Point Up");
		Parent.NoTouch ();
	}

}
