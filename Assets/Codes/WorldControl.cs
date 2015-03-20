using UnityEngine;
using System.Collections;

public class WorldControl : MonoBehaviour {
	
	public static Direction DirectionWithInDecrease(Direction d, bool isIncrease) {
		int intValue = (int)d;
		int nextIntValue = (isIncrease)? intValue + 1 : intValue - 1;
		
		if (nextIntValue < 0) nextIntValue = 3;
		if (nextIntValue > 3) nextIntValue = 0;
		
		return (Direction)nextIntValue;
	}
	
	public static Quaternion RotationWithDirection(Direction d) {
		switch (d) {
		case Direction.Down:  return Quaternion.Euler(0, 0, 0);
		case Direction.Right: return Quaternion.Euler(0, 0, 90);
		case Direction.Top:   return Quaternion.Euler(0, 0, 180);
		case Direction.Left:  return Quaternion.Euler(0, 0, 270);
		default: 			  return Quaternion.Euler(0, 0, 0);
		}
	}
	
	public Direction horizontalDirection {
		get { return _horizontalDirection; }
		set {	
			switch (value) {
			case Direction.Top: 	Physics.gravity = new Vector3(0, _gravityValue, 0); break;
			case Direction.Down: 	Physics.gravity = new Vector3(0,-_gravityValue, 0); break;
			case Direction.Left: 	Physics.gravity = new Vector3(-_gravityValue, 0, 0); break;
			case Direction.Right: 	Physics.gravity = new Vector3( _gravityValue, 0, 0); break;
			}
			_horizontalDirection = value;
		}
	}
	Direction _horizontalDirection = Direction.Down;
	
	
	
	private float _gravityValue;
	
	void Awake() {
		_gravityValue = Mathf.Abs(Physics.gravity.y);
	}
	
	
}
