using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

    public float rotateSpeed = 180f;
    public GameObject player;
    
    SpriteRenderer spritePlayer;
    SpriteRenderer hammerSprite;
    SpriteRenderer pivotSprite;

    public Vector3 rotateAxis;

    // Use this for initialization
    void Start () {
        spritePlayer = player.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        spritePlayer = player.GetComponent<SpriteRenderer>();
        pivotSprite = GetComponent<SpriteRenderer>();


        if (spritePlayer.flipX == false)
        {
            pivotSprite.flipX = false;
            Vector3 eulerAngles = transform.localRotation.eulerAngles;
            eulerAngles += rotateAxis * rotateSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(eulerAngles);
        }

        if (spritePlayer.flipX == true)
        {
            /*Vector3 newScale = gameObject.transform.localScale;
            newScale.x *= -1;
            gameObject.transform.localScale = newScale;*/
            pivotSprite.flipX = true;
            Vector3 eulerAngles = transform.localRotation.eulerAngles;
            eulerAngles += rotateAxis * rotateSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(eulerAngles);
            Quaternion.Inverse(gameObject.transform.localRotation);
            //Debug.Log("flipping");
        }

    }
}
