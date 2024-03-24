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
    private List<Sprite> characterSpriteList;
    private List<Dialogue> dialogueList;

    //pilihan untuk apakah text bakal running atau tidak.
    [SerializeField]
    private bool isRunningText;

    //mengambil object charaSprite.
    [SerializeField]
    private Image charaSprite;

    //mengambil object DialogueText.
    [SerializeField]
    private TMP_Text dialogueText;

    //mengambil object Trigger Button.
    [SerializeField]
    private Button dialogueTrigger;

    private int nextDialogue;
    private bool isTextRunning;

    private void Start()
    {
        SetDialogue();
    }

    private void SetDialogue()
    {
        nextDialogue = 0;
        //mengambil data di DialogueObject.
        GetDialogueData();
        AssignTriggerButton();
        ChangeDialogue();
    }

    private void GetDialogueData()
    {
        DialogueObject dialogueObjectData = Instantiate(dialogueObject);
        dialogueList = dialogueObjectData.dialogue;
        characterSpriteList = dialogueObjectData.charaSprite;
    }

    private void AssignTriggerButton()
    {
        dialogueTrigger.onClick.AddListener(ChangeDialogue);
    }

    private void ChangeDialogue()
    {

        //cek apakah dialog sudah selesai apa tidak
        if (nextDialogue >= dialogueList.Count)
        {
            gameObject.SetActive(false);

            //stop fungsi ChangeDialogue()
            return;
        }

        //get index chara dari enum.
        int charaIndex = (int)dialogueList[nextDialogue].pick;

        //mengganti charaSprite
        charaSprite.sprite = characterSpriteList[charaIndex];

        //cek apakah text berupa running text
        if (!isRunningText)
        {
            dialogueText.text = dialogueList[nextDialogue].dialogueText;

            nextDialogue++;
        }
        else
        {
            StopAllCoroutines();

            string sentence = dialogueList[nextDialogue].dialogueText;

            if (!isTextRunning)
            {
                StartCoroutine(TypeDialogue(sentence));
            }
            else
            {
                dialogueText.text = dialogueList[nextDialogue].dialogueText;

                isTextRunning = false;
                nextDialogue++;
            }
        }
    }

    //if use running Text
    IEnumerator TypeDialogue(string sentence)
    {
        isTextRunning = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            yield return new WaitForSeconds(0.1f); //speed dari running text.
            dialogueText.text += letter;
            yield return null;
        }
        isTextRunning = false;
        nextDialogue++;
    }
}