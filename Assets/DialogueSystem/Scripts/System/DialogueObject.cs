using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueObject", menuName = "DialogueSystem/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    public List<DialogueList> personList;
}

[System.Serializable]
public class DialogueList
{
    public List<Dialogue> dialogue;
}

[System.Serializable]
public class Dialogue
{
    [TextArea] //agar bentuk string menjadi text area.
    public string dialogueText;
    public bool next; // agar memungkinan nantinya saat next bakal di orang yang sama.
}
