﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour {

    public Health target;
    public Image image;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        image.fillAmount = target.PercentHealth();
	}
}
