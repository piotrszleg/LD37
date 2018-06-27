/*/using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class SaveSystemMB : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public int unlockedLevels = 1;
        public int money = -1;
        public bool audio;
        public bool music;
        public Level[] levels;
        public InGameShop.Item[] items;
    }
    public Data data = new Data();
    private const string path = "/save.txt";
    public bool load=true;
    public bool save=true;

    //public MonoBehaviour[] observedBehaviors;
    public Savable[] savables;

    void Start()
    {
        savables = InterfaceHelper.FindObjects<SaveSystemMB.Savable>().ToArray<Savable>();
        if (load)
        {
            Load();
            for (int i = 0; i < savables.Length; i++)
                savables[0].SetValues(data);
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


    public interface Savable{
        void GetValues(ref Data data);
        void SetValues(Data data);
    }
}
*/