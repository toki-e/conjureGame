using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(1);
        }*/

        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene(2);
        }

        if (Input.GetKey(KeyCode.Q)) {
            SceneManager.LoadScene(1);
        }
	}
}
