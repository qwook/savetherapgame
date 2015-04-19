using UnityEngine;
using System.Collections;

public class RapInput : MonoBehaviour {

	string rapString;

	// Use this for initialization
	void Start () {
	
	}
	
	void InputRapKey(string key) {
		rapString += key;
		
		LevelManager lvlMgr = (LevelManager) FindObjectOfType(typeof(LevelManager));
		if ( !lvlMgr.ComparePartial() ) {
			ResetRapString();
		}
	}
	
	public void ResetRapString() {
		rapString = "";
	}
	
	public string GetRapString() {
		return rapString;
	}
	
	void Update() {
		
		foreach (string key in new string[] {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}) {
			
			if (Input.GetKeyDown(key)) {
				InputRapKey(key);
			}
			
		}
		
		if (Input.GetKeyDown("backspace")) {
			ResetRapString();
		}
		
		if (Input.GetKeyDown("space")) {
			InputRapKey (" ");
		}
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
}
