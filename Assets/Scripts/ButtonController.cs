using System.Collections;
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
		
}
