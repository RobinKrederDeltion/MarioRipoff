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


