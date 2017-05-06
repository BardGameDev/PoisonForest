using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {

	public float scale_down = 1f;
	public float orbitDistance = 2f;
	public float orbitDegreesPerSec = 180.0f;
	public string id = "-1";

	private bool isAttached;
	private float front_dist = 1.2f;

	private LevelController controller;
	private GameObject cam;
	private GameObject player;
	private Collider col;
	private Vector3 relativeDistance = Vector3.zero;
	private Vector3 startPos;

	void Start () {
		col = gameObject.GetComponent<Collider> ();
		isAttached = false;
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		player = GameObject.FindGameObjectWithTag ("Player");
		startPos = transform.position;

		controller =  GameObject.FindGameObjectWithTag ("Controller").GetComponent<LevelController>();
	}

	void Update(){ //put any animations for pickup objects here
	}

	public void appear(){
		gameObject.SetActive (true);
	}

	public void off(){
		isAttached = false;
		gameObject.SetActive (false);
	}

	void  LateUpdate(){
		if (isAttached) {
			Orbit ();
		} else {
			transform.Rotate (new Vector3 (1f, 1f, 1f));
		}
	}
		
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("PlayerTrigger")) {
			isAttached = true;
			col.isTrigger = true;
			transform.localScale /= scale_down; // makes object smaller on pickup
			transform.position = calculateAttatchedPosition (); // place object in intial position for orbit (relative to camera)
			relativeDistance = transform.position - player.transform.position;
			controller.pickUpObject(id, gameObject);
		}
	}

	// Calculates the position of the picked up object relative to location of the camera
	Vector3 calculateAttatchedPosition(){ 
		float offsetx = (player.transform.position.x - cam.transform.position.x) * front_dist;
		float offsetz = (player.transform.position.z - cam.transform.position.z) * front_dist;
		float x_pos = cam.transform.position.x + offsetx;
		float z_pos = cam.transform.position.z + offsetz;
		return new Vector3 (x_pos, player.transform.position.y + 1, z_pos);
	}

	void Orbit()
	{
		// Keep us at the last known relative position, to avoid glitches when moving
		transform.position = player.transform.position + relativeDistance;
		transform.RotateAround(player.transform.position , Vector3.up, orbitDegreesPerSec * Time.deltaTime);
		// Reset relative position after rotate
		relativeDistance = transform.position - player.transform.position;
	}

	void Reset() {
		isAttached = false;
		col.isTrigger = false;
		transform.position = startPos;
		transform.localScale *= scale_down;
	}
}
