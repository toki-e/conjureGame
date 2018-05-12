using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public GameObject optionCube;
    public GameObject petalCursor;

    Ray pointRay;
    RaycastHit2D hit;

    Vector2 mousePosition;

	// Use this for initialization
	void Start () {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
	
	// Update is called once per frame
	void Update () {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        petalCursor.transform.position = mousePosition;
        

	}
}
