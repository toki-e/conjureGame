using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conjureTimer : MonoBehaviour {

    public float conjureTimeLeft = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        conjureTimeLeft -= Time.deltaTime;

        if (conjureTimeLeft <= 0)
        {
            Destroy(this.gameObject);
            //conjureTimer = 50f;
        }
    }
}
