using UnityEngine;
using System.Collections;

public class ShowBlood : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Debug.Log(other.name);
	}
}
