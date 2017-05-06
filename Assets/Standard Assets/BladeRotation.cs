using UnityEngine;
using System.Collections;

public class BladeRotation : MonoBehaviour
{
	public bool active = true;
	public float speed = 10f;
	private Transform blades;

	void Start () {
		blades = transform.GetChild(0).GetChild(0).transform;
	}

	void FixedUpdate(){
		if (active) {
			blades.Rotate(new Vector3 (0, 90, 0) * Time.deltaTime * speed);
		}
	}
}