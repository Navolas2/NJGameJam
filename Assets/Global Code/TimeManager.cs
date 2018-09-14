using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {
	//This manages when time should move for all objects. 

	public static TimeManager manager;
	private List<TimeEvent> timelist;

	void Awake(){
		if (manager == null) {
			manager = this;
			timelist = new List<TimeEvent> ();
		}
		if (manager != this) {
			Destroy (this);
		}
	}
	// Use this for initialization
	void Start () {
		
	}

	void Update(){
		if (timelist.Count > 0) {
			foreach (TimeEvent e in timelist) {
				if (e.TickEvent ()) {
					timelist.Remove (e);
				}
			}
		}
	}

	public bool IsTimeMoving(){
		return timelist.Count != 0;
	}

	public void AddEvent(TimeEvent e){
		timelist.Add (e);
	}

	public bool EventExist(TimeEvent e){
		return timelist.Contains (e);
	}

	public void RemoveEvent(TimeEvent e){
		timelist.Remove (e);
	}
}
