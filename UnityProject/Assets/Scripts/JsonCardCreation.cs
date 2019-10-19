using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonCardCreation
{
    private static JsonCardCreation instance;

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
        
        System.IO.StreamReader file = new System.IO.StreamReader("Assets/Resources/basic.deck");
        so.artwork = Resources.Load<Sprite>(file.ReadLine());
        so.text = file.ReadLine();
        so.population = file.ReadLine();
        file.Close();

        return so;
    }

}
