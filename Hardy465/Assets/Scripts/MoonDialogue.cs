using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class MoonDialogue : MonoBehaviour
{
    //private Dialogue DM;

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Moon" + collision);  

        //DM = GameObject.Find("DialogueBox").GetComponent<Dialogue>();

        //if I run into something tagged as "player"
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("COLLIDE");
            //DM.StartDialogue();
        }
    }
}
