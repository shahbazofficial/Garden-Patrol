using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderHealth : Health {

    private float startHealth;

    private void Start() {
        startHealth = health;
    }

    public void HealDamage(float heal) {
        // newHealth is what the health plus the healing total is.
        // if newHealth goes over the defenders maximum health then the health will be capped at the max. 
        // otherwise just add the extra health.
        float newHealth = health += heal;
        if (newHealth > startHealth) {
            health = startHealth;
        } else {
            health = newHealth;
        }
    }
}
