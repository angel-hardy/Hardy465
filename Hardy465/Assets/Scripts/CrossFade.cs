using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossFade : MonoBehaviour
{
    RawImage fade;
    // Start is called before the first frame update
    void Start()
    {
        fade.CrossFadeAlpha(0, 3, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fade()
    {
        //fade.CrossFadeAlpha(0, 3, true);
    }
}
