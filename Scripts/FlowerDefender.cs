using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerDefender : Defender {

    protected UIDisplay flowerDisplay;

    // Use this for initialization
    public void Start() {
        flowerDisplay = GameObject.Find("FlowerDisplay").GetComponent<UIDisplay>();
    }

    public void AddFlower(int amount) {
        flowerDisplay.Add(amount);
    }
}
