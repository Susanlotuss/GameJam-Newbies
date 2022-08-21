using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject dialogSign;
    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;
    private bool dialogIsOpen;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && playerIsClose && !dialogIsOpen)
        {
            dialogIsOpen = true;
            dialoguePanel.SetActive(true);
            zeroText();
            StartCoroutine(Typing());
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

        if (dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    public void NextLine()
    {
        contButton.SetActive(false);
        StopAllCoroutines();

        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            CloseDialog();
        }
    }

    public void CloseDialog()
    {
        dialogIsOpen = false;
        dialoguePanel.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            dialogSign.SetActive(true);
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            dialogSign.SetActive(false);
            playerIsClose = false;
        }
    }
}
