using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GfTimer : MonoBehaviour {

	private int delayDeathAnimation;
	// Use this for initialization
	void Start () {
		delayDeathAnimation = 0;
	}

	// Update is called once per frame
	void Update () {
		int countdown = Blackboard.Instance.getCountdown();
		if (countdown == 0) {
			GetComponent<Animator>().SetBool ("alive", false);
			delayDeathAnimation = (int)Time.time;
		}
		var playerPosition = GameObject.Find ("Player").transform.position;
		if (Vector3.Distance (transform.position, playerPosition) < 5) {
			Blackboard.Instance.setCoundownStopped (true);
		}

		if (delayDeathAnimation != 0 && (int)Time.time - delayDeathAnimation > 1) {
			Blackboard.Instance.setGameState ("lost");
		}
	}
}
