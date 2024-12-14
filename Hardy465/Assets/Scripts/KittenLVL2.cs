using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KittenLVL2 : MonoBehaviour
{
    public float min = 2f;
    public float max = 3f;
    public string SceneName;
    private SceneManager SM;
    private Animator animator;

    // Use this for initialization
    void Start()
    {

        min = transform.position.x;
        max = transform.position.x + 15;

        animator = GetComponent<Animator>();
        SM = GameObject.Find("GameManager").GetComponent<SceneManager>();
        SceneName = SM.SceneName();
        if (SceneName == "Lvl2")
        {
            animator.SetBool("IsWalkingR", true);
            animator.SetBool("IsSittingL", false);
            animator.SetBool("IsSittingR", false);
        }
        else if (SceneName == "Lvl3")
        {
            animator.SetBool("IsWalkingR", false);
            animator.SetBool("IsSittingL", true);
            animator.SetBool("IsSittingR", false);
        }
        else
        {
            animator.SetBool("IsWalkingR", false);
            animator.SetBool("IsSittingL", false);
            animator.SetBool("IsSittingR", true);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (SceneName == "Lvl2")
        {
            MoveAround();
        }
        
      
    }

    private void MoveAround()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);
    }
}