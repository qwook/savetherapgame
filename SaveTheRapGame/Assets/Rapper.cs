using UnityEngine;
using System.Collections;

public class Rapper : MonoBehaviour {

	public string[] verses = new string[] {
		"stop",
		"drop",
		"roll",
		"flip it",
		"yo"
	};
	
	int lineNo = 0;
	
	public string GetCurrentLine() {
//		return verses[lineNo] || "";
		return verses[lineNo];
	}
	
	public void GoToNextLine() {
		lineNo++;
	}
	
	public void IsFinished() {
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
