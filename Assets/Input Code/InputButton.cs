using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate void ButtonAction();
public class InputButton : MonoBehaviour, IPointerClickHandler {

	public string myname;
	public ButtonAction myAction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerClick(PointerEventData data){
		Debug.Log(myname);
	}
}
