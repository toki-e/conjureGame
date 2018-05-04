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

    public GameObject conjureMenuPrefab;
    public GameObject cubePrefab;
    public GameObject mainCam;
    public GameObject petalPrefab;

    public bool menuActive; //= false;
    public bool onGround;
    // public bool canOpenMenu = true;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sprite;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //conjureMenuPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //binding xSpeed to velocity?
        float xSpeed = 0;
        anim.SetBool("still", true);
        anim.SetBool("running", false);

        if (Input.GetKey(rightKey))
        {
            xSpeed += moveSpeed;
            sprite.flipX = false;
            anim.SetBool("running", true);
            anim.SetBool("still", false);
        }
     

        if (Input.GetKey(leftKey))
        {
            xSpeed -= moveSpeed;
            sprite.flipX = true;
            anim.SetBool("running", true);
            anim.SetBool("still", false);
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

        } else if (Input.GetKeyUp(menuKey) || Input.GetMouseButtonUp(1))
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
        else if (menuActive == false) {
            conjureMenuPrefab.SetActive(false);
        }

        if (onGround && Input.GetKeyDown(jumpKey))
        {
            rb.AddForce(Vector2.up * jumpForce);
            onGround = false;
        }

        if (onGround && Input.GetKeyDown(upKey))
        {
            rb.AddForce(Vector2.up * jumpForce);
            onGround = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        bool groundCollision = false;

        foreach (ContactPoint2D contact in collisionInfo.contacts)
        {
            if (contact.point.y <= (transform.position.y - sprite.bounds.extents.y + 0.5f)
                && Mathf.Abs(contact.point.x - transform.position.x) <= sprite.bounds.extents.x - 0.1f)
            {
                groundCollision = true;
                break;
            }
        }
        if (groundCollision)
        {
            onGround = true;
        }
    }

}
