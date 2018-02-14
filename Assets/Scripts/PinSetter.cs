using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	public int lastStandingCount = -1;
	public Text pinCountText;
	public float distancetoRaise = 40f;

	private Ball ball;
	private float lastChangeTime;
	private bool ballEnteredBox = false;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		pinCountText.text = CountStanding ().ToString();

		//if ball has entered box
		if (ballEnteredBox) {
			CheckStanding ();
		}
	}

	public int CountStanding() {

		int pinsStanding = 0;

		foreach (Pin pin in GameObject.FindObjectsOfType<Pin> ()) {
			if (pin.IsStanding()) {
				pinsStanding += 1;
			}
		}
		return pinsStanding;
	}

	void CheckStanding() {
		//Update the laststanding count
		//Call PinshaveSettled
		int currentStanding = CountStanding();

		//Good way to check last time something was changed. 
		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		float settleTime = 3f; //how long to wait for pins to be settled
		if (Time.time - lastChangeTime > settleTime) { //if last change > 3s ago
			PinsHaveSettled();
		}
	}

	void PinsHaveSettled()
	{
		ball.Reset ();
		pinCountText.color = Color.green;
		lastStandingCount = -1; //Indicates pines have settled.
		ballEnteredBox = false;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.GetComponent<Ball>()) {
			pinCountText.color = Color.red;
			ballEnteredBox = true;
		}
	}

	public bool getBallEnteredBox()
	{
		return ballEnteredBox;
	}

	void OnTriggerExit(Collider collider)
	{
		print ("Exit pinsetter trigger: " + collider.gameObject.name);
		if (collider.gameObject.GetComponent<Pin> ()) {
			
			Destroy (collider.gameObject);
		}
	}

	public void RaisePins () {
		//Raise standing pins only by distanceToRaise
		Debug.Log("raising pins");
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin> ()) {
			pin.RaiseIfStanding ();
		}
	}

	public void LowerPins () {
		//Lower standing pins only by distanceToRaise
		Debug.Log("lowering pins");
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin> ()) {
			pin.Lower ();
		}
	}
	public void RenewPins () {
		Debug.Log("Renewing Pins");
	}
}
