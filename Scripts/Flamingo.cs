using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamingo : MonoBehaviour {

	private Animator flamingoAnim;
    private Attacker attacker;

    // Use this for initialization
    void Start() {
        flamingoAnim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D collider) {
        GameObject obj = collider.gameObject;

        //Leave the method if not colliding with method
        if (!obj.GetComponent<Defender>()) {
            return;
        }

        if (obj.GetComponent<Stone>()) {
            return;
        } else {
            flamingoAnim.SetBool("IsAttacking", true);
            attacker.Attack(obj);
        }
    }
}
