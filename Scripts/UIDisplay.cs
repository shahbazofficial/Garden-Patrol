using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class UIDisplay : MonoBehaviour {

	private Text text;
	public int total = 50;
	public enum Status {SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		UpdateDisplay();
	}

	public void Add(int amount){
		total += amount;
		UpdateDisplay();
	}
	
	public Status Use(int amount){
		if(total >= amount){
			total -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
	
	private void UpdateDisplay(){
		text.text = total.ToString();
	}
}
