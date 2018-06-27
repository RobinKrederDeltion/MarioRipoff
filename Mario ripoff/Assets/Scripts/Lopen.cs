using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lopen : MonoBehaviour
{

    public Vector3 A;
    public float hor;
    public float speed;
    private SpriteRenderer mijnSpriteRenderer;
    public Animator anim;
    public bool grounded;
    public float jump;
    private Rigidbody rb;
    public float jumpForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            anim.SetTrigger("Land");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exited");
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
    private void Awake()
    {

        mijnSpriteRenderer = GetComponent<SpriteRenderer>();

    }
        void FixedUpdate()
    {

        hor = Input.GetAxis("Horizontal");
        A.x = hor;
        transform.Translate(A * Time.deltaTime * speed);
        anim.SetFloat("Speed", hor);

        if(Input.GetButtonDown("Jump")&& grounded == true)
        {
            //rb.AddForce(new Vector3(0, jumpForce, 0));
            rb.velocity += Vector3.up * jumpForce;
            anim.SetTrigger("Jump");
        }

        if ( hor < 0)
        {
            mijnSpriteRenderer.flipX = true;


        }
        else if (hor > 0)
        {
            mijnSpriteRenderer.flipX = false;
        }
        } 
    }


