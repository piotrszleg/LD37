using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour {

    public Text speakerHeader;
    public Image speakerImage;
    Sprite defaultSpeakerImage;
    public TextDrawer text;
    Animator anim;
    public Vector3 wordPosition;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(LateStart());
        defaultSpeakerImage = speakerImage.sprite;
    }

    IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();
        //Display("Guy", "0123456789abcdefghijklmnoprstuwxyz");
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void Display(string speakerName, string dialogue, Sprite speakerSprite)
    {
        speakerImage.sprite = speakerSprite;
        Display(speakerName, dialogue);
    }

    public void Display(string speakerName, string dialogue)
    {
        anim.SetTrigger("open");
        speakerHeader.text = speakerName;
        StartCoroutine(Open(dialogue));
    }

    IEnumerator Open(string dialogue)
    {
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).normalizedTime>0.9f);
        text.Text = dialogue;
        text.onFinished.AddListener(()=> StartCoroutine(Close()) );
    }

    IEnumerator Close()
    {
        anim.SetTrigger("close");
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).loop==true);
        speakerImage.sprite = defaultSpeakerImage;
    }
}
