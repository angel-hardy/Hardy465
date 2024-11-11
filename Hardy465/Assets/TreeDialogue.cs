using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class TreeDialogue : MonoBehaviour
{
    private Dialogue DM;
    private string[] sentences = new string[] { "Mom, I found some nice people.", "What do you mean, honey?", "A house without a back porch, they just leave food for me in the grass.", "Be careful. Some food can be traps set by the humans to keep you forever.", "Would that be so bad?", "How will I take care of you if you're gone from me?", "I won't need you to care for me. I would be okay.", "I suppose you would be."};

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //if enemy runs into the laser
        {
            DM = GameObject.Find("DialogueBox").GetComponent<Dialogue>();
            Player P = collision.GetComponent<Player>();
            if (P != null)
            {
                //Debug.Log("GOT EM");
                DM.SetConvo(sentences, "TreeDialogue");
            }
        }
    }
}