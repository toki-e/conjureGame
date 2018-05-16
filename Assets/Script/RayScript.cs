using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour {

    SpriteRenderer sprite;
    SpriteRenderer hammerSprite;
    Rigidbody2D rBSword;
    Renderer currentHighlightedObject = null;

    public GameObject optionCube;
    public GameObject conjureMenu;
    public GameObject cubePrefab;
    public GameObject hammerPrefab;
    public GameObject player;
    public GameObject waterPrefab;
    public GameObject swordPrefab;

    public GameObject photoBubble;
    public GameObject weHaveBubble;
    public GameObject someGoodBubble;
    public GameObject residentsBubble;
    public GameObject iDontNeedBubble;
    public GameObject iShouldBubble;

    public GameObject wellLookBubble;
    public GameObject iSeeBubble;
    public GameObject whatsTheLookBubble;
    public GameObject sureBubble;
    public GameObject huhBubble;
    public GameObject itsBaku;


    public GameObject foyerDoor1;
    public GameObject exclaim;
    public GameObject exclaimBaku;

    public Vector2 playerPos;

    public float conjureTimer = 5;

    public float newsRead = 0;
    public float bakuRead = 0;

    public bool bakuClear = false;
  


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
        rBSword = swordPrefab.GetComponent<Rigidbody2D>();

        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
        playerPos = player.transform.position;
             

        if (hit)
        {
            //Debug.Log(hitInfo.collider);
            Renderer hitRenderer = hit.collider.GetComponent<Renderer>();
            hitRenderer.material.color = Color.blue;

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

                if (hit.collider.gameObject.name == "option4")
                {
                    Debug.Log("sword");
                    if (sprite.flipX == false)
                    {

                        Instantiate(swordPrefab, playerPos + new Vector2(2, 0.5f), Quaternion.identity);

                    }

                    if (sprite.flipX == true)
                    {
                        Instantiate(swordPrefab, playerPos + new Vector2(-5, 0.5f), Quaternion.identity);
                        swordPrefab.transform.rotation = Quaternion.Euler(0, 0, 277f);
                        rBSword = swordPrefab.GetComponent<Rigidbody2D>();
                        swordPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2 (-2,0);
                       // transform.position += Vector3.left * moveSpeedSword * Time.deltaTime;
                    }

                }

                if (hit.collider.gameObject.name == "famfoto") {
                    photoBubble.SetActive(true);
                }

                if (hit.collider.gameObject.name == "bedroomDoor")
                {
                    iDontNeedBubble.SetActive(true);
                }

                if (hit.collider.gameObject.name == "foyerDoor1" && newsRead == 0)
                {
                    iShouldBubble.SetActive(true);

                }

                if (hit.collider.gameObject.name == "news") {

                    newsRead++;

                    if (newsRead == 1)
                    {
                        weHaveBubble.SetActive(true);
                        exclaim.SetActive(false);
                        foyerDoor1.GetComponent<BoxCollider2D>().enabled = false;


                    }

                    if (newsRead == 2)
                    {
                        someGoodBubble.SetActive(true);
                       

                    }

                    if (newsRead == 3) {

                        residentsBubble.SetActive(true);
                        newsRead = 0;
                    }

                }

                if (hit.collider.gameObject.name == "baku")
                {
                    bakuRead++;
                    
                    if(bakuRead == 1)
                    {
                        wellLookBubble.SetActive(true);
                        itsBaku.SetActive(true);
                    }

                    if (bakuRead == 2)
                    {
                        iSeeBubble.SetActive(true);

                    }

                    if (bakuRead == 3)
                    {
                        whatsTheLookBubble.SetActive(true);

                    }

                    if (bakuRead == 4)
                    {
                        sureBubble.SetActive(true);

                    }

                    if (bakuRead == 5) {

                        huhBubble.SetActive(true);
                        bakuClear = true;

                        bakuRead = 0;

                    }

                }


            }

        }
        else if (currentHighlightedObject != null)
        {
            currentHighlightedObject.material.color = Color.white;
            currentHighlightedObject = null;
        }

        if(bakuClear == true)
        {
            exclaimBaku.SetActive(false);
            GameObject.Find("gateClosed").SetActive(false);
        }

    }
}
