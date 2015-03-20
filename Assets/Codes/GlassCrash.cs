using UnityEngine;
using System.Collections;

public class GlassCrash : MonoBehaviour {

	public void CrashMe() {
		foreach (Transform t in transform) {
			if (t.name == "Cube") t.gameObject.SetActive(false);
			if (t.name == "Fragment") {
				t.gameObject.SetActive(true);
				t.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(10, 100), 0, 0));
			}
		}
	}
}
