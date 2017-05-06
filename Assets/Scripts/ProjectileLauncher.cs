using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour {

	public GameObject prefab;
	public float shootForce = 0f;

	void Start () {
		StartCoroutine(fireArrows());
	}

	// Update is called once per frame
	IEnumerator fireArrows(){
		while (true){
			GameObject projectile = Instantiate(prefab,this.transform.position+ this.transform.forward,this.transform.rotation);
			projectile.GetComponent<Rigidbody>().AddForce(this.transform.forward*shootForce);
			yield return new WaitForSeconds(Random.Range(0f,5.0f));
	}
	}

	void Update () {
	}
}
