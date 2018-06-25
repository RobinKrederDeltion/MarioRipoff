using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lopen : MonoBehaviour
{

    public Vector3 A;
    public float hor;
    public float speed;
    private SpriteRenderer mijnSpriteRenderer;
    public Animator anim;
    public bool grounded;
    public float jump;
    private Rigidbody2D rb;
    public float jumpForce;
    private PolygonCollider2D col;
    public bool op;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<PolygonCollider2D>();
    }

    public void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Enemy" && op == false))
        {
            anim.SetBool("Death", true);
            GameManager.instance.Death();
            GameManager.isDead = true;
            col.enabled = false;
            rb.constraints = RigidbodyConstraints2D.FreezePosition;  
        }

        else if ((collision.gameObject.tag == "Enemy" && op == true))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            anim.SetTrigger("Land");
        }
       

    }

    public void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.transform.tag == "Coin")
        {
            print("1");
            CoinManager.instance.IncreaseCoins(1);
            Destroy(collide.gameObject);
            SoundManager.instance.PlayAudio(SoundManager.instance.coinSound);
            

        }

        if (collide.transform.tag == "Fish")
        {
            transform.localScale += new Vector3(1.0F, 1, 1);
            Destroy(collide.gameObject);
            op = true;


        }
    }

    public void OnCollisionExit2D(Collision2D collision)
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
        if (GameManager.isDead == false)
        {
            hor = Input.GetAxis("Horizontal");
            A.x = hor;
            transform.Translate(A * Time.deltaTime * speed);
            anim.SetFloat("Speed", hor);

            if (Input.GetButtonDown("Jump") && grounded == true)
            {
                //rb.AddForce(new Vector3(0, jumpForce, 0));
                rb.velocity += Vector2.up * jumpForce;
                anim.SetTrigger("Jump");
            }

            if (hor < 0)
            {
                mijnSpriteRenderer.flipX = true;


            }
            else if (hor > 0)
            {
                mijnSpriteRenderer.flipX = false;
            }
        }
       
        } 
    }


