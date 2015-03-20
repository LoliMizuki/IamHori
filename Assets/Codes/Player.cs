using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public MoveBand currentMoveBound {
		get { return _currentMoveBound; }
		set {
			_currentMoveBound = value;
			transform.parent = Game.current.moveBandsTransform[_currentMoveBound.direction];
		}
	}
	
	MoveBand _currentMoveBound;
	
	float _rotationColddownCount = 0;

	void Start () {
	
	}
	
	void Update () {
		UpdateMoveControl();
		UpdateWorldRotation();
	}
	
	void UpdateMoveControl() {
		float deltaMove = 100*Time.deltaTime;
		
		if (Input.GetKey(KeyCode.A)) deltaMove *=-1;
		else if (Input.GetKey(KeyCode.D)) deltaMove *=1;
		else return;
		
		float nextX = transform.localPosition.x + deltaMove;

		nextX = Mathf.Max(nextX, currentMoveBound.min);
		nextX = Mathf.Min(nextX, currentMoveBound.max);
		
		transform.localPosition = new Vector3(nextX, transform.localPosition.y, transform.localPosition.z);
	}
	
	void UpdateWorldRotation() {
		if (_rotationColddownCount > 0) _rotationColddownCount -= Time.deltaTime;
		if (_rotationColddownCount > 0) return;
		
		if (!(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))) return;
	
		_rotationColddownCount = 0.5f;
		
		WorldControl worldControl = Game.current.worldControl;
		
		if (Input.GetKey(KeyCode.LeftArrow)) {
			worldControl.horizontalDirection = WorldControl.DirectionWithInDecrease(worldControl.horizontalDirection, true);
		}
		
		if (Input.GetKey(KeyCode.RightArrow)) {
			worldControl.horizontalDirection = WorldControl.DirectionWithInDecrease(worldControl.horizontalDirection, false);
		}
		
		currentMoveBound = Game.current.moveBands[worldControl.horizontalDirection];
		
		transform.localPosition = Vector3.zero + new Vector3(0, 0.931f, 0);
		transform.localRotation = Quaternion.Euler(Vector3.zero);
		
//		Camera.main.transform.localRotation = WorldControl.CameraRotationWithDirection(worldControl.horizontalDirection);
		// update player position 
	}
}
