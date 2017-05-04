using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
	public Text healthText;
	private LevelController controller;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<LevelController>();
		healthText.text = controller.playerHealth.ToString();
	}

	// Update is called once per frame
	void Update () {
		healthText.text = controller.playerHealth.ToString();
	}
}
