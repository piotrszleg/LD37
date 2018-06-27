using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour, SaveSystem.Savable {

    public Transform[] prefabs;

    public void Start()
    {
    
    }

    public void GetValues(ref SaveSystem.Data data)
    {

    }
    public void SetValues(SaveSystem.Data data)
    {
        for(int i=0; i<Mathf.Min(data.items.Length, prefabs.Length) ; i++)
        {
            if (data.items[i].equiped)
            {
                ((Transform)Instantiate(prefabs[i], transform.position, Quaternion.identity)).gameObject.name= data.items[i].name;
            }
        }
    }
}
