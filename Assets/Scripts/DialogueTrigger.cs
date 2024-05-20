using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueSystem dialogue;

    private bool triggered = false;

    public PlayerController Player;

    private Animator anim;

    public void Start()
    {
        Player = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        triggered = false;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            anim.SetTrigger("idle");
            triggered = true;
            dialogue.StartDialogue();
            Debug.Log("diyalog basladi");
        }
    }

}
