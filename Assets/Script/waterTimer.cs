using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterTimer : MonoBehaviour {

    public float waterTimeLeft = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        waterTimeLeft -= Time.deltaTime;

        if (waterTimeLeft <= 0) {
            Destroy(this.gameObject);
        }
	}
}
