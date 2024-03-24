using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueObject", menuName = "DialogueSystem/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    //Membuat List Sprite yang ditampilkan, untuk chara
    public List<Sprite> charaSprite;
    public List<Dialogue> dialogue;
}

[System.Serializable]
public class Dialogue
{
    [TextArea] //agar bentuk string menjadi text area.
    public string dialogueText;

    //Membuat dropdown menu
    public enum Characters { Character1 = 0, Character2 = 1, Character3 = 2, Character4 = 3};
    public Characters pick;
}