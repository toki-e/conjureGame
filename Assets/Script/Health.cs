using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    public float hp;
    public float maxHP = 5f;
    public float minHP = 0f;

    public GameObject dia1;
    public GameObject dia2;
    public GameObject dia3;
    public GameObject dia4;
    public GameObject dia5; 


	// Use this for initialization
	void Start () {
        hp = 5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (hp == 5f)
        {
            dia1.SetActive(true);
            dia2.SetActive(true);
            dia3.SetActive(true);
            dia4.SetActive(true);
            dia5.SetActive(true);
        }
        else if (hp == 4f)
        {
            dia1.SetActive(true);
            dia2.SetActive(true);
            dia3.SetActive(true);
            dia4.SetActive(true);
            dia5.SetActive(false);
        }
        else if (hp == 3f)
        {
            dia1.SetActive(true);
            dia2.SetActive(true);
            dia3.SetActive(true);
            dia4.SetActive(false);
            dia5.SetActive(false);
        }
        else if (hp == 2f)
        {
            dia1.SetActive(true);
            dia2.SetActive(true);
            dia3.SetActive(false);
            dia4.SetActive(false);
            dia5.SetActive(false);
        }
        else if (hp == 1f)
        {
            dia1.SetActive(true);
            dia2.SetActive(false);
            dia3.SetActive(false);
            dia4.SetActive(false);
            dia5.SetActive(false);
        }
        else if (hp == 0f) {
            SceneManager.LoadScene(2);
            dia1.SetActive(false);
            dia2.SetActive(false);
            dia3.SetActive(false);
            dia4.SetActive(false);
            dia5.SetActive(false);
        }
	}
}
