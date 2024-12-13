using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Debug = UnityEngine.Debug;
using System;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    public Boolean MoonDialogue = false;
    public Boolean GrassDialogue = false;
    public Boolean TreeDialogue = false;
    public Boolean GoodbyeDialogue = false;

    private SceneManager SM;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        SM = GameObject.Find("GameManager").GetComponent<SceneManager>();
        //StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            } else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.text = null;
            //change the scene if the convo is over with
            if (MoonDialogue == true)
            {
                SM.ChangeScene("Lvl2");
                MoonDialogue = false;
            }
            else if (GrassDialogue == true)
            {
                SM.ChangeScene("Lvl3");
                GrassDialogue = false;
            }
            else if (TreeDialogue == true)
            {
                SM.ChangeScene("Lvl4");
                TreeDialogue = false;
            } else if (GoodbyeDialogue == true)
            {
                GoodbyeDialogue = false;
                SM.ChangeScene("Credits");
            }
        }
    }

    public void SetConvo(string[] sentences, string dialogue)
    {
        //create just a giant if else statement for specific dialogue
        if (dialogue == "MoonDialogue")
        {
            MoonDialogue = true;
        } else if (dialogue == "GrassDialogue")
        {
            GrassDialogue = true;
        } else if (dialogue == "TreeDialogue")
        {
            TreeDialogue = true;
        } else if (dialogue == "GoodbyeDialogue")
        {
            GoodbyeDialogue= true;
        }
        lines = sentences;
        StartDialogue();
    }
}
