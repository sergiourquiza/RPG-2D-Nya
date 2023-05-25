using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Interaction{
    public Sprite CharacterImage;
    public string CharacterText;
    public string CharacterName;
}

public class Conversation : MonoBehaviour
{
    public List<Interaction> Interactions;
}
