using UnityEngine;
using System.Collections;

public class RapText : MonoBehaviour {

	public RapInput input;
	public Rapper rapper;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		TextMesh filledIn = transform.FindChild("Filled In Text").GetComponent<TextMesh>();
		TextMesh toFillIn = transform.FindChild("To Fill-In Text").GetComponent<TextMesh>();
		
		toFillIn.text = rapper.GetCurrentLine();
		
		LevelManager lvlMgr = (LevelManager) FindObjectOfType(typeof(LevelManager));
		
		if (lvlMgr.currentTurn == LevelManager.TurnState.PlayerTurn) {
			filledIn.text = input.GetRapString();
			
		} else {
			string curLine = rapper.GetCurrentLine();
			filledIn.text = curLine.Substring(0, Mathf.Min(curLine.Length, lvlMgr.enemyTypeStep));
		}
	}
	
}
