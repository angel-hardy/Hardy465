using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GrassDialogue : MonoBehaviour
{
    private Dialogue DM;
    private string[] sentences = new string[] { "Mom, I want to go explore!", "You don't need to go all the way out there just yet.", "I'm grown!", "You're growing, not quite grown yet." };

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //if enemy runs into the laser
        {
            DM = GameObject.Find("DialogueBox").GetComponent<Dialogue>();
            Player P = collision.GetComponent<Player>();
            if (P != null)
            {
                //Debug.Log("GOT EM");
                DM.SetConvo(sentences, "GrassDialogue");
            }
        }
    }
}