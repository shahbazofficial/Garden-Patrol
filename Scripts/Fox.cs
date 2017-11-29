using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour {

	private Animator foxAnimator;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		foxAnimator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		GameObject obj = collider.gameObject;
		
		//Leave the method if not colliding with method
		if(!obj.GetComponent<Defender>()){
			return;
		}
		
		if(obj.GetComponent<Stone>()){
			foxAnimator.SetTrigger("Jump Trigger");
		}else {
			foxAnimator.SetBool("IsAttacking", true);
			attacker.Attack(obj);
		}
	}
}
