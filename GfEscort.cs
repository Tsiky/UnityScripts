using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GfEscort : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var carPosition = GameObject.Find ("Car").transform.position;
		if (Vector3.Distance (transform.position, carPosition) < 5) {
			Blackboard.Instance.setGameState ("won");
		}
	}
}
