using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Rigidbody rigidbody;
	private AudioSource audioSource;
	private bool hasLaunched = false;
	private Vector3 startPos;
	public Vector3 launchVelocity;


	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
		rigidbody.useGravity = false;
		startPos = transform.position;

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

	public void Reset() {
		Debug.Log ("Resetting Ball");
		hasLaunched = false;
		rigidbody.useGravity = false;
		transform.position = startPos;
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
	}
}
