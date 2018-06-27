using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

    public SpeechBalloon speechBalloon;
    public MessageBox messageBox;
    public ChoiceBox choiceBox;
    public TextAsset screenplay;
    public Sprite image;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Speak());
        }
    }

    IEnumerator Speak()
    {
        string text = screenplay.text;
        string collectedText = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '\n')
            {
                messageBox.Display(gameObject.name, collectedText, image);
                collectedText = "";
                yield return new WaitForSeconds(2);
            }
            else
            {
                collectedText += text[i];
            }
        }
        messageBox.Display(gameObject.name, collectedText, image);
    }
}
