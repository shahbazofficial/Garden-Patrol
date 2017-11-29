using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject thisAttacker in attackerPrefabArray){
			if(TimeToSpawn(thisAttacker)){
				Spawn(thisAttacker);
			}
		}
	}
	
	void Spawn(GameObject myGameObject){
		GameObject attacker = Instantiate(myGameObject) as GameObject;
		attacker.transform.parent = transform;
		attacker.transform.position = transform.position;
	}
	
	bool TimeToSpawn(GameObject  attackerGameObject){
		Attacker attackerScript = attackerGameObject.GetComponent<Attacker>();
	
		float meanSpawnDelay = attackerScript.seenEverySeconds;
		float spawnsPerSecond = 1/meanSpawnDelay;
		
		if(Time.deltaTime > meanSpawnDelay){
			Debug.LogWarning("Spawn rate capped by frame rate");
		}
		
		float threshold = spawnsPerSecond * Time.deltaTime/ 4;
		
		return(Random.value < threshold);
	}
}
