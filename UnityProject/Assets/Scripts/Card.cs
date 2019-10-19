using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Card", menuName="Card")]
public class Card : ScriptableObject
{
    public Sprite artwork;

    public string text;

    public string population;

}
