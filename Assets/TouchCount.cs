using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCount : MonoBehaviour {

	public UnityEngine.UI.Text counter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		counter.text = Input.touchCount.ToString();
	}
}
