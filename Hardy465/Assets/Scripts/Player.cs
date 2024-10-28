using System.Collections;
using System.Collections.Generic;
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
    private Rigidbody2D rb;
    private float jumpVelocity = 7f; //strength of jump

    //private Rigidbody rb = GetComponent<Rigidbody>();
    private GameManager GM;
    private UIManager UI;

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();


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
        Move();
        //Bounds();

        //jump code
        if (Input.GetKeyDown(KeyCode.Space) && (Time.time > canJump))
        {
            //change the velocity of the rigidbody to go up quickly
            rb.velocity = Vector2.up * jumpVelocity;
            canJump = Time.time + jumpRate;


        }
    }


    void Move()
    {
        //use WASD without the WS hahaha
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
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
