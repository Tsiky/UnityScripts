using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Blackboard.Instance.setPlayerHealth (100);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
