using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject bala = null;
	
	
	
	float _colddwonCount = 0;

	void Start() {
		_colddwonCount = NextColddownTime();
	}
	
	void Update() {
		UpdateAttack();
	}
	
	void UpdateAttack() {
		if (_colddwonCount > 0) _colddwonCount -= Time.deltaTime;
		if (_colddwonCount > 0) return;
		
		GameObject newBala = GameObject.Instantiate(bala) as GameObject;
		newBala.transform.position = transform.position + new Vector3(0, 1.5f * transform.localScale.y, 0);
		
		var tarPos = Game.current.player.transform.position;
		
		var diff = tarPos - transform.position;
		
		Vector2 diffv2 = new Vector2(diff.x, diff.z);
		
		Vector2 dir = MZ.Maths.UnitVectorFromVector(diffv2);
		
		newBala.GetComponent<Bala>().direction = new Vector3(dir.x, 0, dir.y);
		newBala.GetComponent<Bala>().velocity = 50;
		
		var degrees = MZ.Maths.DegreesFromXAxisToVector(diffv2);
		newBala.transform.rotation = Quaternion.Euler(0, 90 + degrees, 0);
		
//		var vec = tarPos - transform.position;
//		
//		var force3 = new Vector3(-vec.x/100, fy/total, fz/total) * force * transform.localScale.x;
//		
//		
//		newBala.GetComponent<Rigidbody>().AddForce(force3, ForceMode.Force);
//		newBala.transform.localScale = new Vector3(
//			newBala.transform.localScale.x * transform.localScale.x,
//			newBala.transform.localScale.y * transform.localScale.y,
//			newBala.transform.localScale.z * transform.localScale.z
//		);
		
		_colddwonCount = NextColddownTime();
	}
	
	
	float NextColddownTime() {
		return Random.Range(3, 5);
	}

}
