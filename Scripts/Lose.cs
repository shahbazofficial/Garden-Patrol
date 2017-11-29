using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour {

	private int noOfEnemiesEntered;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D(){
		noOfEnemiesEntered ++;
		print (noOfEnemiesEntered);
		LoseCondition();
	}
	
	void LoseCondition(){
		if(noOfEnemiesEntered >= 3){
			levelManager.LoadLevel("03 Lose");
		}
	}
}
