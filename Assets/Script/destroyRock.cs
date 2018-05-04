using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyRock : MonoBehaviour {

    public GameObject pebbles;
    public GameObject hammerPrefab;

    //public float pebbleLife = 2;

    Vector2 pebblePos;
    

	// Use this for initialization
	void Start () {
        pebblePos = new Vector2(transform.position.x, transform.position.y);
	}

    // Update is called once per frame
    void Update()
    {       
        //pebbleLife -= Time.deltaTime;
        //pebbles.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "hammer")
        {
            Destroy(this.gameObject);
            Instantiate(pebbles, pebblePos, Quaternion.identity);
           
            //pebbleLife = 2f;
            //pebbleLife -= Time.deltaTime;
            Debug.Log("hit!");

            /*if (pebbleLife <= 0) {
                Destroy(this.pebbles);
                pebbleDying = false;
                //pebbleLife = 2f;
            }*/

        }
    }

}
