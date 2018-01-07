using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour {

	private int startTimer;
	private int delayMessage;
	private const int TIME_MAX = 60;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		startTimer = (int)Time.time;
		delayMessage = 0;
		Blackboard.Instance.setGameState ("starting");
		Blackboard.Instance.setCoundownStopped (false);
		Blackboard.Instance.setCountdown (TIME_MAX);
	}
	
	// Update is called once per frame
	void Update () {
		int time = (int)Time.time - startTimer;
		int countdown = TIME_MAX - time;
		if (time > 2 && Blackboard.Instance.getGameState () == "starting") {
			Blackboard.Instance.setGameState ("running");
		}
		if (delayMessage == 0 && Blackboard.Instance.getCountdownStopped ()) {
			Blackboard.Instance.setGameState ("escorting");
			delayMessage = time;
		}
		if (time - delayMessage > 2 && Blackboard.Instance.getGameState () == "escorting") {
			Blackboard.Instance.setGameState ("running");
		}
		if (!Blackboard.Instance.getCountdownStopped ()) {
			Blackboard.Instance.setCountdown (countdown);
		}
		if (Blackboard.Instance.getGameState() == "lost" || Blackboard.Instance.getGameState() == "won") {
			Time.timeScale = 0;
		}
	}
}
