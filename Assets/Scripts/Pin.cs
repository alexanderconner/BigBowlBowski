using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	private float standingThreshold = 15; //Determines if pin is still standing.
	public float distToRaise = 40f;

	private Rigidbody rigidbody;

	void Start() {
		rigidbody = GetComponent<Rigidbody> ();
	}

	//Returns true if the pins transform is rotated less than the threshold from vertical
	public bool IsStanding() {

		Vector3 rotationInEuler = transform.rotation.eulerAngles;

		//float tiltInX = Mathf.Abs(rotationInEuler.x);
		//float tiltInZ = Mathf.Abs(rotationInEuler.z);
		float tiltInX = Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.x, -90));
		float tiltInZ = Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.z, 0));

		if (tiltInX < standingThreshold && tiltInZ < standingThreshold) {
			return true;
		}

		return false;
	}

	public void RaiseIfStanding() {
		if (IsStanding ()) {
			rigidbody.useGravity = false;
			transform.Translate (new Vector3 (0, distToRaise, 0), Space.World);
		}
	}

	public void Lower() {
		if (IsStanding ()) {
			transform.Translate (new Vector3 (0, -distToRaise, 0), Space.World);
			rigidbody.useGravity = true;
		}
	}

}
