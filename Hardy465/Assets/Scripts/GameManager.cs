using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool gameOver = true;
    public bool paused = false;

    [SerializeField] private GameObject PauseText;
    [SerializeField] private GameObject Player;

    private UIManager UI; //null right now on its own


    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
            {
                //resume
                Time.timeScale = 1; //100% fps
                paused = false;
                PauseText.SetActive(false);
            }
            else
            {
                //pause
                Time.timeScale = 0; //0 fps
                paused = true;
                PauseText.SetActive(true);
            }
        }

        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //add player
                //Instantiate(Player, new Vector3(0, 0, 0), Quaternion.identity);

                //start the game
                gameOver = false;

                //hide title screen
                UI.HideTitle();

            }
        }
    }
}
