using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySeconds;
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator anim;
	private GameObject gameTimer;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		gameTimer = GameObject.Find("GameTimer");
		if(Time.timeSinceLevelLoad > gameTimer.GetComponent<GameTimer>().levelSeconds/2){
			seenEverySeconds -= 2f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		
		if(!currentTarget){
			anim.SetBool("IsAttacking", false);
		}

	}
	
	void OnTriggerEnter2D(){

	}
	
	public void setSpeed(float speed){
		currentSpeed = speed;
	}
	
	//Called from animator at the time of attacking bool being set to true
	public void StrikeCurrentTarget(float damage){
		if(currentTarget){
			Health health = currentTarget.GetComponent<Health>();
			if(health){
				health.DealDamage(damage);
			}
		}
	}
	
	public void Attack(GameObject obj){
		currentTarget = obj; 
	}
}
