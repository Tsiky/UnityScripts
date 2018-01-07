using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUI : MonoBehaviour {

	private int startTimer;
	private int minutes;
	private int seconds;
	private int timeMax;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		int countdown = Blackboard.Instance.getCountdown();
		GUIText guitext = GetComponent<GUIText> ();
		if (countdown < 0) {
			guitext.text = "finished";
		} else {
			int minutes = countdown / 60;
			int seconds = countdown % 60;
			guitext.text = string.Format ("{0:00}:{1:00}", minutes, seconds);
		}
	}
}

