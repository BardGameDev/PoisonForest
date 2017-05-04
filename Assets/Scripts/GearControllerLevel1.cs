using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearControllerLevel1 : MonoBehaviour {
	private float direction = 1;
	private bool pickUpGearFound;
	private PickUpController pickUpScript;
	private Transform[] gearChildren = new Transform[3];

	public bool buttonPressed;
	public GameObject pickUp;
	public string id = "-1";

	void Start(){
		pickUp = GameObject.FindGameObjectWithTag("GearPickUp");
		pickUpScript = pickUp.GetComponent<PickUpController> ();
		pickUpGearFound = false;

		int i = 0;
		foreach (Transform child in transform) {
			gearChildren[i] = child;
			i++;
		}
	}

	void pressedButton(){
		buttonPressed = true;
	}

	void counterClockwise(){
		if (pickUpGearFound) {
			gearChildren[0].Rotate(new Vector3 (0, 0, -50) * Time.deltaTime * direction);
			gearChildren[1].Rotate(new Vector3 (0, 0, 50) * Time.deltaTime * direction);
			gearChildren[2].Rotate(new Vector3 (0, 0, -50) * Time.deltaTime * direction);
		} else {
			gearChildren[0].Rotate(new Vector3 (0, 0, -50) * Time.deltaTime * direction);
		}
	}

	void clockwise(){
		if (pickUpGearFound) {
			gearChildren[0].Rotate(new Vector3 (0, 0, -50) * Time.deltaTime * direction);
			gearChildren[1].Rotate(new Vector3 (0, 0, 50) * Time.deltaTime * direction);
			gearChildren[2].Rotate(new Vector3 (0, 0, -50) * Time.deltaTime * direction);
		} else {
			gearChildren[0].Rotate(new Vector3 (0, 0, -50) * Time.deltaTime * direction);
		}
	}

	void FixedUpdate () {
		if (buttonPressed) {
			gearChildren[0].Rotate(new Vector3 (0, 0, -50) * Time.deltaTime * direction);
			gearChildren[1].Rotate(new Vector3 (0, 0, 50) * Time.deltaTime * direction);
			gearChildren[2].Rotate(new Vector3 (0, 0, -50) * Time.deltaTime * direction);
		}
	}
}