using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conjureTimerHammer : MonoBehaviour {

    public float conjureTimeLeftH = 1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        conjureTimeLeftH -= Time.deltaTime;

        if (conjureTimeLeftH <= 0)
        {
            Destroy(this.gameObject);
            //conjureTimer = 50f;
        }
    }
}
