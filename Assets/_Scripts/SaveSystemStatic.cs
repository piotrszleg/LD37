using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystemStatic
{
    [System.Serializable]
    public class Data
    {
        public int unlockedLevels = 1;
        public int coins = 0;
        public bool audio;
        public bool music;
        public Level[] levels;
    }
    public static Data data = new Data();
    private const string path = "/save.txt";

    static public void Reset()
    {
        data = new Data();
        Save();
    }

    static public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + path); //you can call it anything you want
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Saved Save: " + Application.dataPath + path);
    }

    static public void Load()
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


    public class Level
    {
        public bool unlocked = false;
        public int stars = 0;
    }
}
