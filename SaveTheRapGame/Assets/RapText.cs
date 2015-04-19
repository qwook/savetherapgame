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
		
		filledIn.text = input.GetRapString();
		toFillIn.text = rapper.GetCurrentLine();
	}
	
}
