using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{

    
    //assign ScriptableObject (DialogueObject).
    [SerializeField]
    private DialogueObject dialogueObject;
    

    //container untuk mengcopy isi dari DialogueObject.
    [SerializeField]
    private List<DialogueList> personList;

    //pilihan untuk apakah text bakal running atau tidak.
    [SerializeField]
    private bool isRunningText;

    //mengambil object DialogueText.
    [SerializeField]
    private TMP_Text dialogueText;

    //mengambil object Trigger Button.
    [SerializeField]
    private Button dialogueTrigger;

    private int personCount;
    private int currentPerson;

    private void Start()
    {
        SetDialogue();
    }

    private void SetDialogue()
    {
        //mengambil data di DialogueObject.
        personList = new(dialogueObject.personList);

        personCount = personList.Count;
        currentPerson = 0;
        AssignTriggerButton();
    }

    private void AssignTriggerButton()
    {
        dialogueTrigger.onClick.AddListener(ChangeText);
    }

    private void ChangeText()
    {
        int dialogueCount;
        dialogueCount = 0;
        for(int i = 0; i < personCount; i++)
        {
            dialogueCount += personList[currentPerson].dialogue.Count;
        }

        Debug.Log(dialogueCount);

        if(currentPerson >= personCount)
        {
            currentPerson = 0;
        }

        dialogueText.text = personList[currentPerson].dialogue[0].dialogueText;

        personList[currentPerson].dialogue.RemoveAt(0);

        currentPerson++;
    }
}
