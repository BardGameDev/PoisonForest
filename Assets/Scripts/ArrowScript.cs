using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {
	private GameObject player;
  private Rigidbody playerRB;
  private LevelController controller;

  public bool active = true;
  public string id = "-1";
	public float duration;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, duration);
		player = GameObject.FindGameObjectWithTag("Player"); //Find player object
		playerRB = player.GetComponent<Rigidbody>();
		controller = GameObject.FindGameObjectWithTag ("Controller").GetComponent<LevelController>();
	}

	void OnTriggerEnter(Collider Other){
    if(Other.gameObject.CompareTag("PlayerTrigger") && active){
      controller.armor--;
	  Destroy(gameObject);
      controller.damageChecking(id);

    }
  }
	// Update is called once per frame
	void Update () {

	}
}
