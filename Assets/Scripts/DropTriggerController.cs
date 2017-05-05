using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTriggerController : MonoBehaviour {

	public string id = "-1";
	public GameObject missingChild;

	void Start(){
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("PlayerTrigger")) {
			GameObject.FindGameObjectWithTag ("Controller").GetComponent<LevelController> ()
				.dropTrigger (id, missingChild);
		}
	}
}
