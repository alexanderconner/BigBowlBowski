using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Ball ball;
	private Vector3 offset;
	private 

	// Use this for initialization
	void Start () {
		offset = gameObject.transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (ball.transform.position.z <= 1750f) // in front of head pin
		{
			gameObject.transform.position = ball.transform.position + offset;
		}
	}
		
}
