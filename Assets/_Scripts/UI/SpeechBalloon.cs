using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeechBalloon : MonoBehaviour {

    public TextDrawer text;
    Animator anim;
    public Vector3 wordPosition;
    Camera cam;
    Transform follow;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        if(follow!=null)transform.position = cam.WorldToScreenPoint(follow.position);
    }

    public void Display(Transform target, string dialogue)
    {
        anim.SetTrigger("open");
        follow = target;
        text.Say(dialogue);
        StartCoroutine(Close());
    }

    IEnumerator Close()
    {
        yield return new WaitUntil(() => !text.drawing);
        anim.SetTrigger("close");
    }

}
