using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold; //Determines if pin is still standing.

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

}
