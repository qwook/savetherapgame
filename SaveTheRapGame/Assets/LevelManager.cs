using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float bpm = 123.0f;
	public Rapper rapper;
	public RapInput input;
	
	public int scorePlayer = 0;
	public int scoreEnemy = 0;
	
	float timeElapsed = 0;
	float lastTime = -1;
	
	float beatTime = 0;
	int discreetBeat = 0;
	
	float nextType = 0;
	public int enemyTypeStep = 0;
	
	int verse = 0;

	public enum State {
		Dialogue,
		CountDown,
		Typing,
		Ending
	}
	
	public enum TurnState {
		PlayerTurn,
		EnemyTurn
	}
	
	public TurnState currentTurn = TurnState.PlayerTurn;
	public State currentState = State.Typing;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (currentState == State.Typing) {
			timeElapsed += Time.fixedDeltaTime;
			beatTime = timeElapsed % (60.0f / bpm);
			
			if (currentTurn == TurnState.EnemyTurn) {
				// typing for the enemy
				if (nextType > ((60.0f / bpm) / 10) && enemyTypeStep <= rapper.GetCurrentLine().Length) {
					nextType = 0;
					if (Random.Range(0, 100) < rapper.messUpProbability) {
						scoreEnemy -= 5;
						ScoreUpdate();
						enemyTypeStep = 0;
					} else {
						enemyTypeStep++;
					}
				}
			}
			
			nextType += Time.fixedDeltaTime;
			
			// beats and stuff
			if (lastTime > beatTime || lastTime == -1) {
				// "bump" the circle
				GetComponent<Animator>().speed = 1/((60.0f / bpm) * 4);
				GetComponent<Animator>().SetTrigger("bump");
				
				if (discreetBeat % 4 == 0) {
					// move the circle in a line
					GetComponent<Animator>().speed = 1/((60.0f / bpm) * 4);
					GetComponent<Animator>().SetTrigger("line");
					
					if (rapper.GetCurrentLine() != "") {
						if (currentTurn == TurnState.PlayerTurn) {
							if (Compare()) {
								scorePlayer += 10;
								ScoreUpdate();
							}
						} else {
							scoreEnemy += 10;
							ScoreUpdate();
						}
					}
					
					BeatUpdate();
					rapper.GoToNextLine();
					
					// after 4 verses, switch turns.
					if (verse % 4 == 0 && verse != 0) {
						if (currentTurn == TurnState.PlayerTurn) {
							currentTurn = TurnState.EnemyTurn;
						} else {
							currentTurn = TurnState.PlayerTurn;
						}
					}
					
					verse++;
				}
				
				discreetBeat ++;
			}
			
			lastTime = beatTime;
		}
	}
	
	void BeatUpdate() {
		enemyTypeStep = 0;
		input.ResetRapString();
	}
	
	public void ScoreUpdate() {
	}
	
	public bool ComparePartial() {
		int len = input.GetRapString().Length;
		int len2 = rapper.GetCurrentLine().Length;
		if (len > len2) return false;
		return input.GetRapString().ToLower() == rapper.GetCurrentLine().Substring(0, len).ToLower();
	}
	
	public bool Compare() {
		return input.GetRapString() == rapper.GetCurrentLine();
	}
}
