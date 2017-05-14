using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public GameObject puzzleObject = null;
	public string id = "-1";
	public int type = -1;
	public float timer = -1;

	private LevelController controller;
	private Renderer rend;
	private bool beenClicked = false;
	private GameObject player;

	void Start(){
		rend = GetComponent<Renderer>();
		controller =  GameObject.FindGameObjectWithTag ("Controller").GetComponent<LevelController>();
		player = GameObject.FindWithTag("Player");
	}

	void OnTriggerEnter(Collider Other) {
		if(Other.gameObject.CompareTag("PlayerTrigger")){
			ToggleClicked ();
			if (type == 1) {
				controller.buttonPressed (id, beenClicked, gameObject, puzzleObject);
			} else if (type == 2) {
				controller.buttonCount (id, timer, beenClicked, gameObject, puzzleObject);
			} else if (type == 3) {
				controller.buttonActivate (id, gameObject, puzzleObject);
			}
		}
	}

	void OnTriggerExit(Collider Other){
		if (Other.gameObject.CompareTag ("PlayerTrigger")) {
			ToggleClicked ();
			if (type == 3) {
				controller.buttonDeactivate (id, puzzleObject);
			}
		}
	}

	public void ToggleClicked(){
		if (beenClicked) {
			rend.material.color = Color.green;
			beenClicked = false;
		} else {
			rend.material.color = Color.red;
			beenClicked = true;
		}
	}

}

//DEREK'S OLD BUTTONCONTROLLER BEFORE 5/4/17

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public GameObject puzzleObject = null;
	public bool independent = true;
	public string id = "-1";

	private LevelController controller;
	private Renderer rend;
	private bool beenClicked = false;

	void Start(){
		rend = GetComponent<Renderer>();
		controller =  GameObject.FindGameObjectWithTag ("Controller").GetComponent<LevelController>();
	}

	void OnTriggerEnter(Collider Other) {
		if(Other.gameObject.CompareTag("PlayerTrigger")){
			if (independent) {
				if (beenClicked) {
					rend.material.color = Color.green;
					beenClicked = false;
				} else {
					rend.material.color = Color.red;
					beenClicked = true;
				}
			}
			controller.buttonPressed (id, beenClicked, gameObject, puzzleObject);
		}
	}

}*/
