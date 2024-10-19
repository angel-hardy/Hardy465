using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject TitleScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideTitle()
    {
        TitleScreen.SetActive(false);
    }

    public void ShowTitle()
    {
        TitleScreen.SetActive(true);

    }
}
