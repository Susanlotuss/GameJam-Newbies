using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialogSign;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogSign.SetActive(true);
            TriggerDialogue();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        dialogSign.SetActive(false);
        FindObjectOfType<DialogueManager>().EndDialogue();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}

