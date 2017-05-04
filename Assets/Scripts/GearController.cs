using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour {
	private float direction = 1;
	public bool buttonPressed;

	void pressedButton(){
		buttonPressed = true;
	}

	void counterClockwise(){
		foreach (Transform child in transform) {
			child.Rotate (new Vector3 (0, 0, -50) * Time.deltaTime * direction);
			direction *= -1;
		}
	}

	void clockwise(){
		foreach (Transform child in transform) {
			child.Rotate (new Vector3 (0, 0, 50) * Time.deltaTime * direction);
			direction *= -1;
		}
	}

	void FixedUpdate () {
		if (buttonPressed) {
			foreach (Transform child in transform) { //When the button is pressed it turns the gears on and they spin
				child.Rotate (new Vector3 (0, 0, 50) * Time.deltaTime * direction);
				direction *= -1;
			}
		}
	}
}