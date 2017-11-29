using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDefender : Defender {

    protected UIDisplay starDisplay;

    // Use this for initialization
    public void Start() {
        starDisplay = GameObject.Find("StarDisplay").GetComponent<UIDisplay>();
    }

    public void AddStars(int amount) {
        starDisplay.Add(amount);
    }
}
