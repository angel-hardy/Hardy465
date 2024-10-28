using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class MoonDialogue : MonoBehaviour
{
    private Dialogue DM;
    private string[] sentences = new string[] {"testing once","testing twice"};

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //if enemy runs into the laser
        {
            DM = GameObject.Find("DialogueBox").GetComponent<Dialogue>();
            Player P = collision.GetComponent<Player>();
            if (P != null)
            {
                //Debug.Log("GOT EM");
                DM.SetConvo(sentences, "MoonDialogue");
            }
        }
    }
}
