using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCube : MonoBehaviour {
    private LevelController controller;
    // Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("Controller").GetComponent<LevelController>();
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerExit(Collider Other){
		if(Other.gameObject.CompareTag("PlayerTrigger")){
			controller.respawn();
		}
	}
}
