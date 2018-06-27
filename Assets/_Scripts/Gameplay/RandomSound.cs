using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomSound : MonoBehaviour {

    float probability = 0.3f;

    // Use this for initialization
    void Start () {
        if (Random.value < probability)
        {
            GetComponent<AudioSource>().Play();
            Debug.Log("Playing sound");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
