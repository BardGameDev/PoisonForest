using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour {

	public GameObject prefab;
	public float shootRate = 0f;
	public float shootForce = 0f;
	public bool on = true;

	void Start () {
		StartCoroutine(fireArrows());
	}

	// Update is called once per frame
	IEnumerator fireArrows(){
		while (on){
			GameObject projectile = Instantiate(prefab,this.transform.position+ this.transform.forward,this.transform.rotation);
			projectile.GetComponent<Rigidbody>().AddForce(this.transform.forward*shootForce);
			yield return new WaitForSeconds(2.0f);
	}
	}

	void Update () {
	}
}
