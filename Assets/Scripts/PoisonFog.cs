using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonFog : MonoBehaviour {
  private GameObject player;
  private Rigidbody playerRB;
  private LevelController controller;
  private int damage = 10;
  private int interval = 1;
  private bool poisoned = false;
  private float nextTime;

  public bool active = true;
  public string id = "-1";

	// Use this for initialization
	void Start () {
    nextTime = 0;
    player = GameObject.FindGameObjectWithTag("Player"); //Find player object
    playerRB = player.GetComponent<Rigidbody>();
    controller = GameObject.FindGameObjectWithTag ("Controller").GetComponent<LevelController>();
	}

  //When the player enters the fog, it starts doing damage by calling the coroutine
  void OnTriggerEnter(Collider Other){
    if(Other.gameObject.CompareTag("PlayerTrigger") && active){
      Debug.Log("Entered the fog");
      poisoned = true;
      StartCoroutine(damageAfterDelay(2.0f));
    }
  }
  //the coroutine here should only iterate once every few seconds so as to not immediately kill the player
  IEnumerator damageAfterDelay(float delay){
    while (poisoned){
      Debug.Log("Activated coroutine");
      controller.playerHealth = controller.playerHealth - damage;
      yield return new WaitForSeconds(delay); //delays the while loop from occuring again until the interval for damage comes again
      controller.damageChecking(id);
    }
  }
  //when the player leaves the fog, the coroutine will stop running by changing the bool "poisoned"
  void OnTriggerExit(Collider Other){
    poisoned = false;
    controller.playerHealth = 100;
  }

	// Update is called once per frame
	void Update () {

	}
}
