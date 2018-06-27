using UnityEngine;

public class YSort : MonoBehaviour {

    Renderer rend;

	void Start () {
        rend = GetComponent<Renderer>();
	}

	void Update () {
        rend.sortingOrder = -(int)transform.position.y;
	}
}
