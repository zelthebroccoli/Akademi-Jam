using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueSystem dialogue;

    private bool triggered = false;

    private PlayerController Wizard;

    public void Start()
    {
        Wizard = GetComponent<PlayerController>();
        triggered = false;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !triggered)
        {

            triggered = true;
            dialogue.StartDialogue();
            Debug.Log("diyalog basladi");
        }
    }

}
