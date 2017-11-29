using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour {

	//Time during which panel fades from black
	public float FadeInTime;
	
	//Delcaring variables for the panel and its colour
	private Image fadePanel;
	private Color currentColour = Color.black;

	// Use this for initialization
	void Start () {
		//Getting the Image component and attaching it to the variable
		fadePanel = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		//Calculates what percentage of change should be done to the alpha per frame 
		if(Time.timeSinceLevelLoad < FadeInTime){
			float alphaChange = Time.deltaTime/FadeInTime;
			currentColour.a-= alphaChange;
			fadePanel.color = currentColour;
		}else{
			//Deactivating the panel after fade in time has expired so that buttons can be clicked
			gameObject.SetActive(false);
		}
	}
}
