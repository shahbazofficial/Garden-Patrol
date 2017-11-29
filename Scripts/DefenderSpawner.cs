using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	
	private GameObject defenderParent;
	private UIDisplay starDisplay;
	
	void Start(){
		defenderParent = GameObject.Find("Defenders");
		starDisplay = GameObject.FindObjectOfType<UIDisplay>();
		
		if(!defenderParent){
			defenderParent = new GameObject("Defenders");
		}
	}
	
	void OnMouseDown(){
			Vector2 selectedDefenderPos = SnapToGrid(CalculateWorldPointOfMouseClick());
			GameObject defender = Button.selectedDefender;
			
			int defenderCost = defender.GetComponent<Defender>().starCost;
			if(starDisplay.Use(defenderCost) == UIDisplay.Status.SUCCESS){
				SpawnDefender (selectedDefenderPos, defender);
			}else{
				Debug.Log ("Insufficient stars to spawn");
			}
	}
	
	void SpawnDefender (Vector2 selectedDefenderPos, GameObject defender)
	{
		Quaternion zeroRot = Quaternion.identity;
		GameObject newDef = Instantiate (defender, selectedDefenderPos, zeroRot) as GameObject;
		newDef.transform.parent = defenderParent.transform;
	}
	
	Vector2 SnapToGrid(Vector2 rawWorldPos){
		float newX = Mathf.RoundToInt(rawWorldPos.x);
		float newY = Mathf.RoundToInt(rawWorldPos.y);
	
		return new Vector2(newX, newY);
	}
	
	Vector2 CalculateWorldPointOfMouseClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
		
		return worldPos;
	}
}
