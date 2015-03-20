using UnityEngine;
using System;
using System.Collections.Generic;

public enum Direction {
	Unknow = -1,
	Down   = 0,
	Left   = 1,
	Top    = 2,
	Right  = 3,
}



public class Game : MonoBehaviour {

	public static Game current { get { return GameObject.Find("Game").GetComponent<Game>(); } }
	
	public WorldControl worldControl { get; internal set; }
	
	public GameObject player { get; internal set; }
	
	public Dictionary<Direction, MoveBand> moveBands { get; internal set; }
	
	public Dictionary<Direction, Transform> moveBandsTransform { get; internal set; }
	
	void Awake() {
		player = GameObject.Find("Player").gameObject;
		
		worldControl = GetComponent<WorldControl>();
		
		moveBands = new Dictionary<Direction, MoveBand>();
		moveBands[Direction.Top]   = GameObject.Find("MoveBand - Top").GetComponent<MoveBand>(); 
		moveBands[Direction.Top].direction = Direction.Top;
		moveBands[Direction.Down]  = GameObject.Find("MoveBand - Down").GetComponent<MoveBand>();
		moveBands[Direction.Down].direction = Direction.Down;
		moveBands[Direction.Left]  = GameObject.Find("MoveBand - Left").GetComponent<MoveBand>();
		moveBands[Direction.Left].direction = Direction.Left;
		moveBands[Direction.Right] = GameObject.Find("MoveBand - Right").GetComponent<MoveBand>();
		moveBands[Direction.Right].direction = Direction.Right;
		
		Action<MoveBand, Direction> addNewBandTransformToDictionary = (moveBand, direction) => {
			if (moveBandsTransform == null) moveBandsTransform = new Dictionary<Direction, Transform>();
			
			GameObject bandObj = new GameObject("MoveBand Transform - " + direction.ToString());
			bandObj.transform.position = moveBand.transform.position;
			bandObj.transform.rotation = moveBand.transform.rotation;
			
			moveBandsTransform.Add(direction, bandObj.transform);
		};
		
		addNewBandTransformToDictionary(moveBands[Direction.Top], Direction.Top);
		addNewBandTransformToDictionary(moveBands[Direction.Down], Direction.Down);
		addNewBandTransformToDictionary(moveBands[Direction.Left], Direction.Left);
		addNewBandTransformToDictionary(moveBands[Direction.Right], Direction.Right);
		
		player.GetComponent<Player>().currentMoveBound = moveBands[Direction.Down];
	}
	
	void Start() {
//		player.GetComponent<Player>()
	}
}
