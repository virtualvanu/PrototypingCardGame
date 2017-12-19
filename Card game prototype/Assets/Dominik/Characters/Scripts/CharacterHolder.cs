using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHolder : MonoBehaviour
{ 
    public Character character;

    private void Awake()
    {
        character.SetUp();
    }


}
