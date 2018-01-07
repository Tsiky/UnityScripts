using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GUIText guitext = GetComponent<GUIText> ();

		switch (Blackboard.Instance.getGameState ()) {
		case "starting":
			guitext.text = "find your girlfriend";
			guitext.color = Color.white;
			break;
		case "escorting":
			guitext.text = "Go back to your car";
			guitext.color = Color.white;
			break;
		case "lost":
			guitext.text = "wasted";
			guitext.color = Color.red;
			break;
		case "won":
			guitext.text = "success";
			guitext.color = Color.white;
			break;
		default:
			guitext.text = "";
			break;
		}
	}
}
