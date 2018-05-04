using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pebbleTimer : MonoBehaviour {

    public float pebbleTime;

	// Use this for initialization
	void Start () {
        pebbleTime = 2f;
	}

    // Update is called once per frame
    void Update()
    {
        pebbleTime -= Time.deltaTime;

        if (pebbleTime <= 0) {
            Destroy(gameObject);
        }


    }
}
