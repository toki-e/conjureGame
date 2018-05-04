using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour {

    SpriteRenderer sprite;
    SpriteRenderer hammerSprite;
    Renderer currentHighlightedObject = null;

    public GameObject optionCube;
    public GameObject conjureMenu;
    public GameObject cubePrefab;
    public GameObject hammerPrefab;
    public GameObject player;
    public GameObject waterPrefab;

    public Vector2 playerPos;

    public float conjureTimer = 5;

    // Use this for initialization
    // void Start () {

    //}

    // Update is called once per frame
    void Update () {

        /* Vector2 mouseScreenPos = Input.mousePosition;
         //mouseScreenPos.z = 0;
         Ray2D mouseRay = Camera.main.ScreenPointToRay(Vector 2(mouseScreenPos));
         RaycastHit2D hitInfo;*/
        sprite = player.GetComponent<SpriteRenderer>();
        hammerSprite = hammerPrefab.GetComponent<SpriteRenderer>();

        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
        playerPos = player.transform.position;
        

        if (hit)
        {
            //Debug.Log(hitInfo.collider);
            Renderer hitRenderer = hit.collider.GetComponent<Renderer>();
            hitRenderer.material.color = Color.red;

            if (currentHighlightedObject != hitRenderer && currentHighlightedObject != null)
            {
                currentHighlightedObject.material.color = Color.white;
            }
            currentHighlightedObject = hitRenderer;

            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject.name == "option1") 
                {
                    if (sprite.flipX == false)
                    {
                        Debug.Log("spawn cube");
                        Instantiate(cubePrefab, playerPos + new Vector2(2, 0), Quaternion.identity);
                        hammerSprite.flipX = false;
                        /*conjureTimer -= conjureTimer*Time.deltaTime;
                        Debug.Log(conjureTimer);*/
                    }

                    if (sprite.flipX == true) {
                        Instantiate(cubePrefab, playerPos + new Vector2(-2, 0), Quaternion.identity);
                        hammerSprite.flipX = true;
                    }

                }

                if (hit.collider.gameObject.name == "option2") {

                    if (sprite.flipX == false)
                    {

                        Debug.Log("spawn hammer");
                        Instantiate(hammerPrefab, playerPos + new Vector2(2, 0.5f), Quaternion.identity);
                    }

                    if (sprite.flipX == true) {
                        Instantiate(hammerPrefab, playerPos + new Vector2(-4, 0.5f), Quaternion.identity);
                    }
                }

                if (hit.collider.gameObject.name == "option3") {

                    if (sprite.flipX == false) {

                        Instantiate(waterPrefab, playerPos + new Vector2(2, 0.5f), Quaternion.identity);

                    }

                    if (sprite.flipX == true) {
                        Instantiate(waterPrefab, playerPos + new Vector2(-3, 0.5f), Quaternion.identity);
                    }

                }

            }

        }
        else if (currentHighlightedObject != null)
        {
            currentHighlightedObject.material.color = Color.white;
            currentHighlightedObject = null;
        }


    }
}
