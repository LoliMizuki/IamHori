using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {

	public float velocity;
	
	public Vector3 direction = Vector3.zero;

	void Start() {
	
	}
	
	void Update() {
		var deltaMove = velocity*Time.deltaTime;
	
		transform.position = new Vector3(
			transform.position.x + deltaMove*direction.x,
			transform.position.y + deltaMove*direction.y,
			transform.position.z + deltaMove*direction.z
		);
	}
}
