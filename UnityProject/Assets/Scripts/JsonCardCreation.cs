using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonCardCreation
{
    private static JsonCardCreation instance;

    public Sprite img;

    public static JsonCardCreation GetInstance()
    {
        if(instance == null)
        {
            instance = new JsonCardCreation();
        }
        return instance;
    }

    public Card GetCard()
    {
        var so = ScriptableObject.CreateInstance<Card>();
        so.population = "Wow";
        so.artwork = img;
        so.text = "Sample card";

        Debug.Log(JsonUtility.ToJson(so));
        return so;
    }

}
