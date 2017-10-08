using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof( Ball)) ]
public class DragLaunch : MonoBehaviour {

	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;
	private Ball ball;


	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball> ();
	}

	public void MoveStart(float amount) {
		Debug.Log ("Ball moved " + amount);
		if (ball.GetHasLaunched() == false) { // If the ball hasn't launched yet we can adjust it

			if ((ball.transform.position.x + amount) < 50f && (ball.transform.position.x + amount) > -50f) { // Keep ball in bounds of lane
				ball.transform.Translate (new Vector3 (amount, 0, 0));
			}
		}
	}
	 
	public void DragStart() {
		//Capture time and position of drag start
		dragStart = Input.mousePosition;
		startTime = Time.time;
	}

	public void DragEnd() { //Swipe control system
		//launch the ball
		if (ball.GetHasLaunched() == false) {
			dragEnd = Input.mousePosition;
			endTime = Time.time;

			float dragDuration = endTime - startTime;

			float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

			Vector3 launchVelocity = new Vector3 (launchSpeedX, 0, launchSpeedZ);

			ball.Launch (launchVelocity);
			print (ball.GetHasLaunched());
		}
	}
}
