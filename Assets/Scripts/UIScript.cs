using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
	public Text healthText;
	public Text armor;
	private LevelController controller;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<LevelController>();
		healthText.text = "Poison Resistance " + controller.playerHealth.ToString();
		armor.text = "Armor " + controller.armor.ToString();
	}

	// Update is called once per frame
	void Update () {
		healthText.text = "Poison Resistance " + controller.playerHealth.ToString();
		armor.text = "Armor " + controller.armor.ToString();
	}
}
