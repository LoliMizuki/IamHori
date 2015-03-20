using UnityEngine;
using UnityEditor;
using System.Collections;

public class MoveBand : MonoBehaviour {
	
	public float length {
		get { return transform.localScale.x; }
		set { transform.localScale = new Vector3(value, 0, 1); }
	}
	
	public Direction direction = Direction.Unknow;
	
	public float min { get { return - transform.localScale.x/2; } }
	
	public float max { get { return transform.localScale.x/2; } }
	
	public float mid { get { return (min + max)/2; } }
}



//[CustomEditor(typeof(MoveBand))]
//public class MoveBoundEditor: Editor {
//	
//	public override void OnInspectorGUI() {
//		base.OnInspectorGUI();
//		_moveBound.length = EditorGUILayout.FloatField("Length", _moveBound.length);
//	}
//	
//	
//	
//	MoveBand _moveBound;
//	
//	void OnEnable() {
//		_moveBound = target as MoveBand;
//	}
//	
//}