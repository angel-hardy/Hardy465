using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Hosting;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class Player : MonoBehaviour
{
    //global variables
    [SerializeField] private LayerMask platformsLayerMask; //describes which layers to hit with our raycast for jumping
    public float speed = 6.0f;
    private float jumpRate = 1f;
    private float canJump = 0.3f;
    public bool canMove = true;
    private Rigidbody2D rb;
    private float jumpVelocity = 7f; //strength of jump

    //private Rigidbody rb = GetComponent<Rigidbody>();
    private GameManager GM;
    private UIManager UI;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();



        //UI.UpdateLives(lives);
        //SM.StartSpawn();

        //get rigidbody reference
        rb = transform.GetComponent<Rigidbody2D>();
        //teleport to center
        //transform.position = new Vector3(0, -5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
            //Bounds();

            //jump code
            if (Input.GetKeyDown(KeyCode.Space) && (Time.time > canJump))
            {
                //change the velocity of the rigidbody to go up quickly
                rb.velocity = Vector2.up * jumpVelocity;
                canJump = Time.time + jumpRate;
                if (Input.GetKey(KeyCode.A))
                {
                    animator.SetBool("IsJumpingL", true);
                    animator.SetBool("IsJumpingR", false);
                    animator.SetBool("IsWalkingR", false);
                    animator.SetBool("IsWalkingL", false);
                    animator.SetBool("IsSitting", false);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    animator.SetBool("IsJumpingL", false);
                    animator.SetBool("IsJumpingR", true);
                    animator.SetBool("IsWalkingR", false);
                    animator.SetBool("IsWalkingL", false);
                    animator.SetBool("IsSitting", false);
                }
            }
        }
    }


    void Move()
    {
        //use WASD without the WS hahaha
        if (Input.GetKey(KeyCode.A))
        {
            if (!(Input.GetKeyDown(KeyCode.Space) && (Time.time > canJump)))
            {
                animator.SetBool("IsJumpingR", false);
                animator.SetBool("IsJumpingL", false);
                animator.SetBool("IsWalkingR", false);
                animator.SetBool("IsWalkingL", true);
                animator.SetBool("IsSitting", false);
            }
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (!(Input.GetKeyDown(KeyCode.Space) && (Time.time > canJump)))
            {
                animator.SetBool("IsJumpingR", false);
                animator.SetBool("IsJumpingL", false);
                animator.SetBool("IsWalkingR", true);
                animator.SetBool("IsWalkingL", false);
                animator.SetBool("IsSitting", false);
            }
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        else
        {
            animator.SetBool("IsJumpingR", false);
            animator.SetBool("IsJumpingL", false);
            animator.SetBool("IsWalkingR", false);
            animator.SetBool("IsWalkingL", false);
            animator.SetBool("IsSitting", true);

            
        }
        float HorizontalInput = Input.GetAxis("Horizontal");
    }

    void Bounds()
    {
        //no upper bound >:-)
        if (transform.position.y < -3f) //lower bound
        {
            transform.position = new Vector3(transform.position.x, -3f, 0);
        }

    } //closes bounds()


}
