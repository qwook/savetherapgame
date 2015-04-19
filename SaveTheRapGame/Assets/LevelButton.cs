using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {

	public bool locked = true;
	public string sceneName;
	private Button button;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startLevel() {
		if (GetComponent<Button> ().interactable) {
			Application.LoadLevel(this.sceneName);
		}
	}

	public void setLocked (bool toLock) {
		GetComponent<Button> ().interactable = toLock;
	}
}
