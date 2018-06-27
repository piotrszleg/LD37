using UnityEngine;
using System.Collections;

public class MessageTrigger : MonoBehaviour {

    public SpeechBalloon balloon;
    public string text;
    public bool pointAtPlayer = false;

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            balloon.Display((pointAtPlayer ? other.transform : transform), text);
        }
    }
}
