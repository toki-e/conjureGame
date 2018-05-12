using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeTimer : MonoBehaviour {

    public float timeToDeactivate = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeToDeactivate -= Time.deltaTime;

        if (timeToDeactivate <= 0) {
            gameObject.SetActive(false);
            timeToDeactivate = 3f;
        }

	}
}
