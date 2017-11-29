using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour {

	private Animator lizardAnimator;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		lizardAnimator = GetComponent<Animator>();
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
		
		lizardAnimator.SetBool("IsAttacking", true);
		attacker.Attack(obj);
	}
}
