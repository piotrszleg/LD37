using UnityEngine;

public class LevelSelect : MonoBehaviour, SaveSystem.Savable {

    [System.Serializable]
    public class Level
    {
        public bool unlocked = false;
        public int stars = 0;
    }
    public Level[] levels;
    public Transform container;
    public LevelUIElement levelPrefab;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GetValues(ref SaveSystem.Data data)
    {
        data.levels=levels;
    }
    public void SetValues(SaveSystem.Data data)
    {
        if (data.levels != null && data.levels.Length>0)
        {
            levels = data.levels;
        }
        for (int i = 0; i < levels.Length; i++)
        {
            LevelUIElement levelUI = (LevelUIElement)Instantiate(levelPrefab, container);
            levelUI.Set(levels[i].unlocked, levels[i].stars);
        }
    }
}