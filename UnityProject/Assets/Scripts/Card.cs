using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName="New Card", menuName="Card")]
public class Card : ScriptableObject
{
    public Sprite artwork;

    public string text;

    public string population;

}
