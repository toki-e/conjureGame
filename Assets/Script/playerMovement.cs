using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class playerMovement : MonoBehaviour
{

    public KeyCode rightKey = KeyCode.D;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode downKey = KeyCode.S;
    public KeyCode upKey = KeyCode.W;
    public KeyCode menuKey = KeyCode.Q;
    public KeyCode jumpKey = KeyCode.Space;

    public float moveSpeed = 10f;
    public float jumpForce = 100f;
    public float jumpTimer = 2f;
    public float downForce = 5f;

    public GameObject conjureMenuPrefab;
    public GameObject cubePrefab;
    public GameObject mainCam;
    public GameObject petalPrefab;

    public bool menuActive; //= false;
    public bool onGround;
    public bool isFalling;
    public bool isRunning;
    // public bool canOpenMenu = true;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sprite;
    Vector2 fallValue;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        fallValue = new Vector2 (0, -2);
        //conjureMenuPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //binding xSpeed to velocity?
        float xSpeed = 0;

        /*if (xSpeed == 0)
        {
            anim.SetBool("still", true);
            anim.SetBool("running", false);
            anim.SetBool("falling", false);
        }*/

        if (rb.velocity.x == 0 && onGround) {
            anim.SetBool("still", true);
            anim.SetBool("running", false);
            anim.SetBool("falling", false);
        }


        //jumpTimer -= Time.deltaTime;
        //anim.SetBool("jumping", false);

        if (onGround)
        {
            isFalling = false;
            anim.SetBool("falling", false);
        }
        else {
            isFalling = true;
        }

        if (isFalling) {
            onGround = false;
        }

        if (Input.GetKey(rightKey))
        {
            xSpeed += moveSpeed;
            sprite.flipX = false;
            isRunning = true;

            if (onGround)
            {
                anim.SetBool("running", true);
                anim.SetBool("still", false);
                anim.SetBool("jumping", false);
            }

        }


        if (Input.GetKey(leftKey))
        {
            xSpeed -= moveSpeed;
            sprite.flipX = true;
            isRunning = true;
            //anim.SetBool("still", false);

            if (onGround)
            {
                anim.SetBool("running", true);
                anim.SetBool("still", false);
                anim.SetBool("jumping", false);
            }
        }


        rb.velocity = new Vector2(xSpeed, rb.velocity.y);  //don't move this up it won't work

        /*if (xSpeed <= 0) {
            anim.SetBool("still", true);
            anim.SetBool("running", false);
        }*/

        if (Input.GetKeyDown(menuKey) || Input.GetMouseButtonDown(1))
        {
            //bring up menu when Q pressed
            //conjureMenuPrefab.transform.position = gameObject.transform.position;

            menuActive = true;
            Instantiate(petalPrefab, transform.position, Quaternion.identity);
            //canOpenMenu = false;

            //conjureMenuPrefab.SetActive(true);
            Debug.Log("activating");

        }
        else if (Input.GetKeyUp(menuKey) || Input.GetMouseButtonUp(1))
        {
            menuActive = false;
            //canOpenMenu = true;
            //Destroy(this.conjureMenuPrefab); //trying to destroy bring down the menu
        }

        if (menuActive == true)
        {
            conjureMenuPrefab.SetActive(true);
            //Instantiate(conjureMenuPrefab, gameObject.transform.position, Quaternion.identity);
        }
        else if (menuActive == false)
        {
            conjureMenuPrefab.SetActive(false);
        }

        /* if (onGround && Input.GetKeyDown(jumpKey))
         {
             rb.AddForce(Vector2.up * jumpForce);
             onGround = false;
             anim.SetBool("jumping", true);
             anim.SetBool("still", false);
             anim.SetBool("running", false);
         }*/

        jumpTimer -= Time.deltaTime;

        //fix this makes still glitch between running frames
        if (onGround && jumpTimer <= 0)
        {
            /*anim.SetBool("still", true);
            anim.SetBool("running", false);*/
            anim.SetBool("jumping", false);

           /* if (isRunning == true) {
                anim.SetBool("still", false);
                anim.SetBool("running", true);
                anim.SetBool("jumping", false);
            }*/

            jumpTimer = 1f;
        }

        if (onGround && Input.GetKeyDown(upKey) || onGround && Input.GetKeyDown(jumpKey))
        {
            rb.AddForce(Vector2.up * jumpForce);
            onGround = false;
            jumpTimer = 1f;
            anim.SetBool("jumping", true);

        }

        if (Input.GetKeyDown(jumpKey) || Input.GetKeyDown(upKey))
        {
            anim.SetBool("jumping", true);
            anim.SetBool("still", false);
            anim.SetBool("running", false);
        }

        if (rb.velocity.y < 0.2f) {

            if (jumpTimer <= 0)
            {
                isFalling = true;

                if (isFalling)
                {
                    anim.SetBool("falling", true);
                    rb.AddForce(Vector2.down * downForce);

                    anim.SetBool("jumping", false);
                    anim.SetBool("still", false);
                    anim.SetBool("running", false);
                }
                else if (isFalling == false) {

                    anim.SetBool("still", true);

                    anim.SetBool("falling", false);
                    anim.SetBool("running", false);
                    anim.SetBool("jumping", false);
                    
                }

            }

        }

    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        bool groundCollision = false;

        foreach (ContactPoint2D contact in collisionInfo.contacts)
        {
            if (contact.point.y <= (transform.position.y - sprite.bounds.extents.y + 1f)
                && Mathf.Abs(contact.point.x - transform.position.x) <= sprite.bounds.extents.x - 0.1f)
            {
                groundCollision = true;
                break;
            }
        }
        if (groundCollision)
        {
            onGround = true;
            isFalling = false;
        }

    }


}
