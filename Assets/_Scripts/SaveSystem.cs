using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public int unlockedLevels = 1;
        public int money = -1;
        public bool audio;
        public bool music;
        public LevelSelect.Level[] levels;
        public InGameShop.Item[] items;
    }
    public Data data = new Data();
    private const string path = "/save.txt";
    public bool load = true;
    public bool save = true;

    //public MonoBehaviour[] observedBehaviors;
    public Savable[] savables;

    public static SaveSystem current;

    void Start()
    {
        savables = InterfaceHelper.FindObjects<SaveSystem.Savable>().ToArray<Savable>();
        if (load)
        {
            Load();
            for (int i = 0; i < savables.Length; i++)
            {
                if (((Behaviour)savables[i]).enabled)
                {
                    Debug.Log("Loaded data to: "+((Behaviour)savables[i]).gameObject.name);
                    savables[i].SetValues(data);
                }
                //Debug.Log("Data sent to "+ savables[i].ToString());
            }
        }
        current = this;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F2)&&Application.isEditor)
        {
            Reset();
            save = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnDestroy()
    {
        if (save)
        {
            for (int i = 0; i < savables.Length; i++)
                savables[i].GetValues(ref data);
            Save();
        }
    }

    public void Reset()
    {
        data = new Data();
        Save();
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + path);
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Saved Save: " + Application.dataPath + path);
    }

    public void Load()
    {
        if (File.Exists(Application.dataPath + path) && new FileInfo(Application.dataPath + path).Length > 0)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + path, FileMode.Open);
            data = (Data)bf.Deserialize(file);
            file.Close();
            Debug.Log("Loaded Save: " + Application.dataPath + path);
        }
    }

    public void Log()
    {
        Load();
        Debug.Log(JsonUtility.ToJson(data));
    }

    public interface Savable
    {
        void GetValues(ref Data data);
        void SetValues(Data data);
    }
}

