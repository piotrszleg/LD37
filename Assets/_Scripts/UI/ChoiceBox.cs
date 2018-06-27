using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChoiceBox : MonoBehaviour {

    public Button[] buttons;
    public Text[] labels;

	// Use this for initialization
	void Start () {
        buttons = GetComponentsInChildren<Button>();
        labels = GetComponentsInChildren<Text>();
        Display("Choose a number?", 
            new string[2] { "1", "2" },
            new UnityAction[2] {()=>Debug.Log(1), ()=>Debug.Log(2)}
            );
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Display(string question, string[] buttonLabels, UnityAction[] actions)
    {
        labels[0].text = question;
        for (int i=0; i < buttons.Length; i++)
        {
            if (actions.Length > i)
            {
                buttons[i].gameObject.SetActive(true);
                labels[i + 1].text = buttonLabels[i];
                buttons[i].onClick.RemoveAllListeners();
                buttons[i].onClick.AddListener(()=>gameObject.SetActive(false));
                buttons[i].onClick.AddListener(actions[i]);
            }else
            {
                buttons[i].gameObject.SetActive(false);
            }
        }
    }
}
