﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public string Name;
	//How long the attacks from this weapon take
	public int AnimationTime;
	//how much damage this weapon will deal
	public float Damage;
	//range of this weapon
	public Vector2 Range;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector2 OrientedRange(int orientation){
		if (orientation == 0 || orientation == 2) {
			return Range;
		} else {
			return new Vector2 (Range.y, Range.x);
		}
	}
}
