using UnityEngine;
using System.Collections;
using System.Reflection;

public class SandboxScript : MonoBehaviour
{
    InGameShop shop;

    void Start()
    {
        shop=GameObject.FindObjectOfType<InGameShop>();
        //FieldInfo[] propertyInfo = typeof(MonoBehaviour);
        //foreach(FieldInfo p in propertyInfo)
         //   Debug.Log(p);
        //Debug.Log( propertyInfo.GetValue(shop, null));
    }
}

/*
void ReadBehaviours()
    {
        foreach (System.Reflection.MemberInfo i in observedBehaviors[0].GetType().GetMembers())
        {
            FieldInfo[] propertyInfo = typeof(InGameShop).GetFields();

            object[] attributes = i.GetCustomAttributes(false);
            foreach (object a in attributes)
            {
                if (a.GetType() == typeof(Savable))
                {
                    propertyInfo[0].GetValue(i);
                }
            }
        }
    }
*/