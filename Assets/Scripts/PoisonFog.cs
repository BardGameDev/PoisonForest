using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonFog : MonoBehaviour {
  private GameObject player;
  private LevelController controller;
  private int damage = 10;
  private bool poisoned = false;

  public bool active = true;
  public string id = "-1";

	// Use this for initialization
	void Start () {
    player = GameObject.FindGameObjectWithTag("Player"); //Find player object
    controller = GameObject.FindGameObjectWithTag ("Controller").GetComponent<LevelController>();
	}

  //When the player enters the fog, it starts doing damage by calling the coroutine
  void OnTriggerEnter(Collider Other){
    if(Other.gameObject.CompareTag("PlayerTrigger") && active){
      //Debug.Log("Entered the fog");
      poisoned = true;
      StartCoroutine(damageAfterDelay(0.5f));
    }
  }
  //the coroutine here should only iterate once every few seconds so as to not immediately kill the player
  IEnumerator damageAfterDelay(float delay){
    while (poisoned){
      //Debug.Log("Activated coroutine");
      controller.playerHealth = controller.playerHealth - damage;
      yield return new WaitForSeconds(delay); //delays the while loop from occuring again until the interval for damage comes again
      controller.damageChecking(id);
    }
  }
  //when the player leaves the fog, the coroutine will stop running by changing the bool "poisoned"
  void OnTriggerExit(Collider Other){
    if(Other.gameObject.CompareTag("PlayerTrigger") && active){
      //Debug.Log("Exit Fog");
      poisoned = false;
      controller.playerHealth = 100;
    }
  }

	// Update is called once per frame
	void Update () {

	}
}
