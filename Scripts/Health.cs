using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	[Range (50f, 500f)]
	public float health;

    public void DealDamage(float damage){
		health -= damage;
		if(health < 0){
			DestroyObject();
		}
	}
	
	public void DestroyObject(){
		Destroy(gameObject);
	}
}
