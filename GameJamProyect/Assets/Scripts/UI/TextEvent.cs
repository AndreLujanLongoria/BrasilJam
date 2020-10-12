using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Text Event")]
public class TextEvent : ScriptableObject
{
    [TextArea(14, 10)] public string text;
}
