using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text pinCountText;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		pinCountText.text = CountStanding ().ToString();
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
}
