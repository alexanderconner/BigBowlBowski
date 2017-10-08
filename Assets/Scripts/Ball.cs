﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Rigidbody rigidbody;
	private AudioSource audioSource;
	private bool hasLaunched = false;
	public Vector3 launchVelocity;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
		rigidbody.useGravity = false;

	}
		
	public void Launch(Vector3 velocity)
	{
		hasLaunched = true;
		rigidbody.useGravity = true;
		rigidbody.velocity = velocity;
		audioSource.Play ();

	}

	public bool GetHasLaunched() 
	{
		return hasLaunched;
	}
}
