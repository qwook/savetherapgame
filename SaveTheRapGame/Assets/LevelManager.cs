using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float bpm = 123.0f;
	public Rapper rapper;
	public RapInput input;
	
	float timeElapsed = 0;
	float lastTime = 0;
	
	float beatTime = 0;
	int discreetBeat = 0;

	enum State {
		Dialogue,
		Typing,
		Ending
	}
	
	State currentState = State.Typing;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (currentState == State.Typing) {
			timeElapsed += Time.fixedDeltaTime;
			beatTime = timeElapsed % (60.0f / bpm);
			if (lastTime > beatTime) {
				GetComponent<Animator>().speed = 1/((60.0f / bpm) * 4);
				GetComponent<Animator>().SetTrigger("bump");
				discreetBeat ++;
				
				if (discreetBeat % 4 == 0) {
					GetComponent<Animator>().speed = 1/((60.0f / bpm) * 4);
					GetComponent<Animator>().SetTrigger("line");
					BeatUpdate();
					
					rapper.GoToNextLine();
				}
			}
			
			lastTime = beatTime;
		}
	}
	
	void BeatUpdate() {
		input.ResetRapString();
	}
	
	public bool ComparePartial() {
		int len = input.GetRapString().Length;
		int len2 = rapper.GetCurrentLine().Length;
		if (len > len2) return false;
		return input.GetRapString() == rapper.GetCurrentLine().Substring(0, len);
	}
	
	public bool Compare() {
		return input.GetRapString() == rapper.GetCurrentLine();
	}
}
