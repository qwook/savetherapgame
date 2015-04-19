using UnityEngine;
using System.Collections;

public class TugOfWar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		LevelManager lvlMgr = (LevelManager) FindObjectOfType(typeof(LevelManager));
		int diff = lvlMgr.scorePlayer - lvlMgr.scoreEnemy;
		
		Transform disc = transform.FindChild("Disc");
		Vector3 position = disc.localPosition;
		position.x = (float) diff/10;
		disc.transform.localPosition = position;
	}
}
