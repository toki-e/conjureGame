using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseClick : MonoBehaviour {

    public bool clickedOption1 = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(clickedOption1 == true) {
            
              //  Debug.Log("spawn cube!");
            
        }
	}

    private void OnMouseDown()
    {
        clickedOption1 = true;
        Debug.Log("spawn cube");
    }
}
