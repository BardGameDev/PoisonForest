using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
	public Text healthText;
	public Text armor;
	public Text won;
	private LevelController controller;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<LevelController>();
		healthText.text = "Resistance to Poision: " + controller.playerHealth.ToString();
		armor.text = "Remaining Health: " + controller.armor.ToString();
		won.text = "";
	}

	// Update is called once per frame
	void Update () {
		healthText.text = "Resistance to Poision: " + new string ('\u2623', controller.playerHealth/10);
		armor.text = "Remaining Health: " + new string ('\u2764', controller.armor);
		if (controller.gameWon) {				
			won.text = "\u2713 \u2713 MISSION COMPLETE \u2713 \u2713";
		} else {
			won.text = "";
		}
	}
}
