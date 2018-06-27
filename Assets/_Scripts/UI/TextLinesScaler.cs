using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class TextLinesScaler : MonoBehaviour {

    Text text;
    public int numberOfLines=2;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        text.fontSize = Mathf.FloorToInt(text.rectTransform.rect.height / numberOfLines)-2;
    }
}
