using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Effect", menuName = "Effect")]
public class Effect : ScriptableObject
{
    public string effectName = "Effect";
    public Sprite sprite;
}