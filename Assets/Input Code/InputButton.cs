using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate void ButtonAction();
public class InputButton : MonoBehaviour, TimeEvent,  IPointerClickHandler {

	public string myname;
	public ButtonAction myAction;

	public UnityEngine.UI.Text TextBox;
	int pointer_ID;
	private int TimeNeeded = 20;
	private int TimeRemaining;
	// Use this for initialization
	void Start () {
		TimeRemaining = TimeNeeded;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				Touch t = Input.GetTouch (Input.touchCount - 1);
				pointer_ID = t.fingerId;
				bool res = EventSystem.current.IsPointerOverGameObject (pointer_ID) && EventSystem.current.currentSelectedGameObject == this;
				if (res) {
					Debug.Log (" a b");
					//TextBox.text = "hi " + myname;
					pointer_ID = -1;
				} else {
					//TextBox.text = "no button";
				}
			} else if (Input.GetTouch (Input.touchCount - 1).phase == TouchPhase.Ended) {
				if (pointer_ID != -1) {
					Touch t = Input.GetTouch (Input.touchCount - 1);
					if (pointer_ID == t.fingerId) {
						bool res = EventSystem.current.IsPointerOverGameObject (pointer_ID);
						if (res) {
							TextBox.text = myname;
							TimeManager.manager.AddEvent (this);
							TimeRemaining = TimeNeeded;
						}
					}
				}
			}
		}
	}

	public void OnPointerClick(PointerEventData data){
		Debug.Log(myname);
	}

	public void OnSelect(BaseEventData eventData){
		TextBox.text = "I am select";
	}

	public bool TickEvent(){
			if (TimeRemaining != -1) {
				TimeRemaining--;
			}
			return TimeRemaining == 0;
		}
}
