using UnityEngine;
using System.Collections.Generic;

public class CharacterSelect : MonoBehaviour {

    [System.Serializable]
    public class MyClass
    {
        public string name;
        public int level;
        public float timeElapsed;
        public string playerName;
    }

    // Use this for initialization
    void Start() {



        MyClass myObject = new MyClass();
        myObject.level = 1;
        myObject.timeElapsed = 47.5f;
        myObject.playerName = "Dr Charles Francis";
        object[] arr = { myObject};
        Debug.Log(JsonUtility.ToJson(arr[0]));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
