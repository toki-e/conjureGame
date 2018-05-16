using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordControl : MonoBehaviour {

    public float moveSpeedSword = 2;
    Vector3 rotateVector;
    Vector3 flippedRotate;

    SpriteRenderer spritePlayer;
    SpriteRenderer sr;
    Rigidbody2D rb;

    public GameObject player;

	// Use this for initialization
	void Start () {

        spritePlayer = player.GetComponent<SpriteRenderer>();
        sr = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();

        rotateVector = new Vector3(0, 0, -2f);
        flippedRotate = new Vector3(0, 0, 2f);
	}
	
	// Update is called once per frame
	void Update () {

        //sr = GetComponent<SpriteRenderer>();
        //transform.Rotate(rotateVector*moveSpeedSword);

        if (spritePlayer.flipX == false)
        {
            //transform.Rotate(Vector3.back);
            //transform.Rotate(rotateVector * moveSpeedSword);

            transform.rotation = Quaternion.Euler(0, 0, -93f);
            transform.Translate(0f, 0.2f, 0f);

           // transform.Rotate(0, moveSpeedSword, 0, Space.World);
        }

        if (spritePlayer.flipX == true)
        {
            /*Vector3 newScale = gameObject.transform.localScale;
            newScale.x *= -1;
            gameObject.transform.localScale = newScale;*/
            //transform.Rotate(-rotateVector * moveSpeedSword);
            //transform.Rotate(flippedRotate * moveSpeedSword);

            sr.flipX = true;

            //transform.Rotate(Vector3.left);
            //rb.velocity = new Vector2(-2,0);

            transform.rotation = Quaternion.Euler(0, 0, 277f);
            transform.Translate(0f, -0.2f, 0f);
            transform.position += Vector3.left * moveSpeedSword * Time.deltaTime;
            Debug.Log("back");

            //transform.Rotate(Vector3.left * Time.deltaTime * moveSpeedSword);

            //Debug.Log("flipping");
        }

    }
}
