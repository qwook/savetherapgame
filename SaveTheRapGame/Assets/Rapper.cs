using UnityEngine;
using System.Collections;

public class Rapper : MonoBehaviour {

	public float messUpProbability = 0.0f;

	public string[] verses = new string[] {
		"stop, drop roll",
		"get it in before the troll",
		"split it up before you go",
		"spit it out inside the flow",
		"keep it up, grind it up yo"
	};

	private string[] words;
	public TextAsset lyrics;
	
	int lineNo = -1;
	
	public string GetCurrentLine() {
		if (lineNo < 0 || lineNo >= verses.Length) return "";
		return verses[lineNo];
	}
	
	public void GoToNextLine() {
		lineNo++;
	}
	
	public void IsFinished() {
	}

	// Use this for initialization
	void Start () {
		string text = lyrics.text;
		char[] delimiters = {'\n'};
		verses = text.Split (delimiters);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
