﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void GotHit() {
        SceneManager.LoadScene("Scenes/Menu");
        //Debug.Log("scenereload");
    }
}
