using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour {

    Animator anim;

    public GameObject swordPrefab;
    public float enemyHealth = 2f;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(enemyHealth == 0)
        {
            Destroy(gameObject);
            anim.SetBool("attacking", true);
        }

	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "sword")
        {
            enemyHealth--;
        }
    }

}
