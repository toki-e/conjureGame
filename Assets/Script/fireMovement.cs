using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireMovement : MonoBehaviour {

    public float fireSpeed = 5f;
    public GameObject player;
    public float playerHP;
    public GameObject water;

    public float fireDiesTimer = 1.5f;

	// Use this for initialization
	void Start () {

       // water = GameObject.Find("water");
      

	}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * fireSpeed);
        fireDiesTimer -= Time.deltaTime;

        if (fireDiesTimer <= 0) {
            Destroy(this.gameObject);
            fireDiesTimer = 1.5f;
        }

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player") {

            GameObject player = GameObject.Find("Player");
            Health playerHP = player.GetComponent<Health>();

            playerHP.hp -= 1;
            Debug.Log("lit");
            Destroy(this.gameObject);

        }

        if (coll.gameObject.tag == "water") {
            Destroy(this.gameObject);
        }

    }

}
