using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour {

    int checkRate = 1;
    public GameObject panel;
    public Text score;
    public Image blackScreen;
    public Color finalBlackScreenColor;
    public float fadeSpeed = 10;
    bool fading = false;

	// Use this for initialization
	void Start () {
        panel.SetActive(false);
        blackScreen.color = Color.clear;
	}

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            if (!fading)
            {
                Show();
                fading = true;
            }
        } else
        {
            fading = false;
        }
    }

    public void Show()
    {
        StartCoroutine(BlackOut());
    }

    IEnumerator BlackOut()
    {
        float lerpTime=0;
        Color startColor = blackScreen.color;
        while (true)
        {
            lerpTime += Time.deltaTime*fadeSpeed;
            blackScreen.color=Color.Lerp(startColor, finalBlackScreenColor, lerpTime);
            yield return new WaitForEndOfFrame();
            Debug.Log("Fading");
            if(blackScreen.color== finalBlackScreenColor)
            {
                BlackOutEnd();
                break;
            }
        }
    }
    void BlackOutEnd()
    {
        panel.SetActive(true);
        Points points = FindObjectOfType<Points>();
        score.text = points.GetScore().ToString()+" points";
        points.gameObject.SetActive(false);
    }
}
