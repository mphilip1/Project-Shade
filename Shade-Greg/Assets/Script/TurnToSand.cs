﻿using UnityEngine;
using System.Collections;

public class TurnToSand : MonoBehaviour {

    public ParticleSystem sandSystem;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
            sandSystem.Play();
            
        }
	}
}
