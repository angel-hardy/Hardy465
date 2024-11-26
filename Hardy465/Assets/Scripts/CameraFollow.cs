using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    private float focusShift = 0f;
    //private Boolean onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //try to make it so that when you're on the ground, the camera positions itself a little higher...
        //if (collision.gameObject.name == "Ground")
        //{
        //focusShift = 2f;
        //onGround = true;
        //} else
        //{
        //focusShift = 0f;
        //onGround = false;
        //}
        if (target.position.y > 10f && target.position.x > 26f) {
            Vector3 newPos = new Vector3(30f, 12f, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        } else {
            Vector3 newPos = new Vector3(target.position.x, (target.position.y + focusShift), -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
        
    }
}
