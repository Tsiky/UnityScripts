using UnityEngine;
using System.Collections;

public class Blackboard : MonoBehaviour {
	private string gameState;
	private int countdown;
	private bool countdownStopped;
	private int playerHealth;

	static readonly Blackboard instance = new Blackboard();

	static Blackboard(){
      
    }
	public static Blackboard Instance {get {return instance;}}

	// Setters
	public void setGameState (string value) {
		gameState = value;
	}
	public void setCountdown (int value) {
		countdown = value;
	}

	public void setCoundownStopped (bool value) {
		countdownStopped = value;
	}

	public void setPlayerHealth (int value) {
		playerHealth = value;
	}

	// Getters
	public string getGameState() {
		return gameState;
	}

	public int getCountdown() {
		return countdown;
	}

	public bool getCountdownStopped() {
		return countdownStopped;
	}

	public int getPlayerHealth()  {
		return playerHealth;
	}
}
