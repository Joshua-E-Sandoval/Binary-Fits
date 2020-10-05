using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    public Camera camera;


    public float velocity = 5,
                 angleGO,
                 angleCam,
                 turnSpeed = 2,
                 camSpeed = 2,
                 camSpeed2 = 2,
                 camOffsetHorizontal = 10,
                 camOffsetVertical = 8;

    // animator variable refrences
    private float hozState = 0, 
                  vertState = 0;

                 
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        camera.transform.position = rb.position - new Vector3(camOffsetHorizontal, -camOffsetVertical, 0);
        camera.transform.LookAt(this.transform);
    }

    void Update()
    {
        //turn Controls
        if (Input.GetKey(KeyCode.A))
        {
            hozState = 0.5f;
            angleCam += camSpeed2 / 100;
            transform.Rotate(0, -turnSpeed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            hozState = -0.5f;
            angleCam -= camSpeed2 / 100;
            transform.Rotate(0, turnSpeed, 0);
        }

        //forward and back
        if (Input.GetKey(KeyCode.W))
        {
            vertState = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vertState = -1;
        }

        //
        if (Input.GetKey(KeyCode.L))
        {
            angleCam += camSpeed/100;
        }
        if (Input.GetKey(KeyCode.J))
        {
            angleCam -= camSpeed/100; 
        }
        if (Input.GetKey(KeyCode.I))
        {
            camOffsetHorizontal += 0.1f;
            camOffsetHorizontal += 0.1f;
        }
        if (Input.GetKey(KeyCode.K))
        {
            camOffsetHorizontal -= 0.1f;
            camOffsetHorizontal -= 0.1f;
        }
        animate();
        setCam();

        hozState = 0;
        vertState = 0;
    }

    void animate()
    {
        animator.SetFloat("Horizontal", hozState);
        animator.SetFloat("Vertical", vertState);
    }
    void setCam()
    {
        camera.transform.position = rb.position - new Vector3(camOffsetHorizontal * Mathf.Cos(angleCam + Mathf.PI), -camOffsetVertical, camOffsetHorizontal * Mathf.Sin(angleCam + Mathf.PI));
        camera.transform.LookAt(this.transform);
    }
}
