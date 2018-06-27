using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Points : MonoBehaviour {

    Text text;
    int points=0;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = points.ToString();
	}

    public void Score(int amount)
    {
        points+=amount;
    }
    public void Score()
    {
        points++;
    }
    public int GetScore()
    {
        return points;
    }
}
