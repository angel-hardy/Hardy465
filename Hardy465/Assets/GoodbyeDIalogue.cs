using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GoodbyeDialogue : MonoBehaviour
{
    private Dialogue DM;
    private string[] sentences = new string[] { "Mom, I love you.", "I need to go on my own now.", "The humans want to take care of me.", "I managed to get out to say goodbye, but I don't know if I can do this again.", "Okay.", "I love you honey.", "I love you." };

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //if enemy runs into the laser
        {
            DM = GameObject.Find("DialogueBox").GetComponent<Dialogue>();
            Player P = collision.GetComponent<Player>();
            if (P != null)
            {
                //Debug.Log("GOT EM");
                DM.SetConvo(sentences, "GoodbyeDialogue");
            }
        }
    }
}