using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(Text))]
public class TextDrawer : MonoBehaviour
{
    Text display;
    private string text;
    public string Text
    {
        get
        {
            return text;
        }
        set
        {
            text = value;
            Say(value);
        }
    }
    public float speed = 10f;
    public float forgetTime = 0.5f;
    public Player player;
    public bool stopPlayer;
    public UnityEvent onFinished;
    public bool drawing = false;
    int maximalChars = 10;

    // Use this for initialization
    void Start()
    {
        display = GetComponent<Text>();
        display.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }
    /*
        s=Helloooooooooooooooooooooooooooooooooo
        [i]=Hello
        [i+1]=oooooooooooo
    */

    public void Say(string text)
    {
        List<string> toDisplay = new List<string>();
        int i = 0;
        toDisplay.Add(text);
        while (((string)toDisplay[i]).Length > maximalChars)
        {
            string s = (string)toDisplay[i];
            toDisplay.Add(s.Remove(0, maximalChars));
            toDisplay[i]=s.Remove(maximalChars);
            i++;
        }
        StartCoroutine(DisplayText(toDisplay.ToArray()) );
    }
    public void Say(string[] text)
    {
        string[] toDisplay = text;
        StartCoroutine(DisplayText(toDisplay));
    }

    IEnumerator DisplayText(string[] text)
    {
        if (drawing)
        {
            yield break;
        }
        drawing = true;
        if (player != null && stopPlayer)
        {
            player.canMove = false;
        }
        for (int i = 0; i < text.Length; i++)
        {
            display.text = "";
            for (int j = 0; j < text[i].Length; j++)
            {
                if (Input.GetButton("Jump") && stopPlayer)
                {
                    display.text = text[i];
                    break;
                }
                display.text += text[i][j];
                yield return new WaitForSeconds(1 / speed);
            }
            yield return new WaitForSeconds(forgetTime);
        }
        display.text = "";
        if (player != null && stopPlayer)
        {
            player.canMove = true;
        }
        if (onFinished != null)
        {
            onFinished.Invoke();
        }
        drawing = false;
    }
}