using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPadController : MonoBehaviour {
	private LevelController controller;
	private int rotating_speed;
	private string direction;

	public GameObject puzzleObject;
	public GameObject Pad;
	public string id = "-1";

	void Start(){
		controller = GameObject.FindGameObjectWithTag ("Controller").GetComponent<LevelController> ();
	}

	void OnTriggerEnter(Collider Other){
		if (gameObject.CompareTag ("CounterClockwise")) { // checks which way pad should be rotated
			rotating_speed = -10;
			direction = "counterClockwise";
		} else {
			rotating_speed = 10;
			direction = "clockwise";
		}

	}

	void OnTriggerStay(Collider Other){
		if(Other.gameObject.CompareTag("PlayerTrigger")){
			Pad.transform.Rotate(new Vector3 (0, rotating_speed,  0) * Time.deltaTime);
			controller.cPadUsed (id, direction, puzzleObject);
		}
	}

}
