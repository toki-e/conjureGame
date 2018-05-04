using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeToAttack : MonoBehaviour {


    Animator anim;

    public GameObject fireballPrefab;

    public float timeToGetLit = 4f;
    Vector2 enemyPos;
	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        enemyPos = transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("attacking", false);
        timeToGetLit -= Time.deltaTime;

        if (timeToGetLit <= 0)
        {
            Instantiate(fireballPrefab, enemyPos + new Vector2(-2, 0), Quaternion.identity);
            anim.SetBool("attacking", true);
            timeToGetLit = 3f;
        }    

    }
}
