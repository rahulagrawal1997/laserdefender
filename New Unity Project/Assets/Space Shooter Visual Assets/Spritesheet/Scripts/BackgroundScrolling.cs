﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour {

	[SerializeField] float backgroungScrollspeed=1.0f;
	Material myMaterial;
	Vector2 offset;
	// Use this for initialization
	void Start () {
		myMaterial = GetComponent<Renderer> ().material;
		offset = new Vector2 (0f, backgroungScrollspeed);
		
	}
	
	// Update is called once per frame
	void Update () {
		myMaterial.mainTextureOffset += offset * Time.deltaTime;
		
	}
}
