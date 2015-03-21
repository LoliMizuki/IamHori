using UnityEngine;
using System.Collections;

public class ShowBlood : MonoBehaviour {
	
	bool _hasGirder = false;
	
	bool _hasHeavyBox = false;
	
	void OnCollisionEnter(Collision collisionInfo) {
		if (_hasGirder && _hasHeavyBox) return;
	
		if (collisionInfo.collider.name == "Girder - Left") _hasGirder = true;
		if (collisionInfo.collider.name == "Heavy-Box") _hasHeavyBox = true;
		
		if (_hasGirder && _hasHeavyBox) {
			GameObject.Find("Blood - 1").GetComponent<MeshRenderer>().enabled = true;
			GameObject.Find("Blood - 2").GetComponent<MeshRenderer>().enabled = true;
		}
	}
}
