using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public float maxDash;
    public float maxWalk;
    public float moveForce;
    public float jumpForce;
    public GameObject camManager;

    private SpriteRenderer sprRender;
    private Animator sprAnimator;
    private Rigidbody2D charRigidbody;
    //private Collider2D jumpCollider;

    public bool isJump = true;
    private bool isDash = false;

    private int lCounter = 0;
    private int rCounter = 0;

    private float lCooler = 0.5f;
    private float rCooler = 0.5f;

    // For animation
    void Awake()
    {
        sprRender = GetComponent<SpriteRenderer>();
        sprAnimator = GetComponent<Animator>();
        //jumpCollider = GetComponent<Collider2D>();
    }

    // Use this for initialization
    void Start () {
        charRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (camManager.GetComponent<CamTrack>().gameOver == false)
        {
            if ((Input.GetKey("space") || Input.GetKey("up") || Input.GetKey("w")) && !isJump)
            {
                //gameObject.transform.position += new Vector3(0, .015f, 0);
                charRigidbody.AddForce(new Vector2(0, jumpForce));
                isJump = true;
                //Debug.Log("Jump!");
            }

            if (Input.GetKey("left") || Input.GetKey("a"))
            {
                charRigidbody.AddForce(new Vector2(-moveForce, 0));
                //Debug.Log("Left!");
            }

            if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
            {
                if (isDash && rCounter > 0)
                {
                    isDash = false;
                    rCounter = 0;
                }

                if (lCounter == 1)
                {
                    isDash = true;
                }

                if (lCounter == 0)
                {
                    lCounter = 1;
                    lCooler = 0.5f;
                }
            }

            if (Input.GetKey("right") || Input.GetKey("d"))
            {
                charRigidbody.AddForce(new Vector2(moveForce, 0));
                //Debug.Log("Right!");
            }

            if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
            {
                if (isDash && lCounter > 0)
                {
                    isDash = false;
                    lCounter = 0;
                }

                if (rCounter == 1)
                {
                    isDash = true;
                }

                if (rCounter == 0)
                {
                    rCounter = 1;
                    rCooler = 0.5f;
                }
            }

            if (Input.GetKey("down") || Input.GetKey("s"))
            {
                //Debug.Log("Crouch!");
            }

            if (Input.GetKeyUp("right") || Input.GetKeyUp("d") || Input.GetKeyUp("left") || Input.GetKeyUp("a"))
            {
                isDash = false;
            }

            if (isDash)
            {
                if (Mathf.Abs(charRigidbody.velocity.x) > maxDash)
                {
                    if (charRigidbody.velocity.x > 0)
                    {
                        charRigidbody.velocity = new Vector2(maxDash, charRigidbody.velocity.y);
                    }
                    else
                    {
                        charRigidbody.velocity = new Vector2(-maxDash, charRigidbody.velocity.y);
                    }
                }
            }
            else
            {
                if (Mathf.Abs(charRigidbody.velocity.x) > maxWalk)
                {
                    if (charRigidbody.velocity.x > 0)
                    {
                        charRigidbody.velocity = new Vector2(maxWalk, charRigidbody.velocity.y);
                    }
                    else
                    {
                        charRigidbody.velocity = new Vector2(-maxWalk, charRigidbody.velocity.y);
                    }
                }
            }

            lCooler -= Time.deltaTime;
            rCooler -= Time.deltaTime;

            if (lCooler <= 0)
            {
                lCounter = 0;
            }

            if (rCooler <= 0)
            {
                rCounter = 0;
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (charRigidbody.velocity.y <= .5)
        {
            isJump = false;
        }
        //Debug.Log("Landed!");
    }

    void OnTriggerExit2D(Collider2D col)
    {
        isJump = true;
        //Debug.Log("Jumped!");
    }
}
